using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;

namespace BLL.Application.GZL.CG
{
    public class ApplyProceed
    {
        public static t_GZL_Actor getActorByItemGuid(Guid itemid)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                t_GZL_TaskList task = dc.t_GZL_TaskList.Where(t => t.itemGuid == itemid).Single();
                return dc.t_GZL_Actor.Where(a => a.actorId == task.actorId).Single();
            }
        }
        public static t_GZL_Actor getActorByItemId(int itemid)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                t_GZL_Item item = dc.t_GZL_Item.Where(i => i.ItemId == itemid).Single();
                t_GZL_TaskList task = dc.t_GZL_TaskList.Where(t => t.itemGuid == item.itemGuid).Single();
                if (task.actorId != -1)
                    return dc.t_GZL_Actor.Where(a => a.actorId == task.actorId).Single();
                else
                    return null;
            }
        }

        public static bool setCompleteState(Guid itemguid,String opinion,String operatorname,int operatorUserId)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                
                t_GZL_TaskList task = dc.t_GZL_TaskList.Where(t => t.itemGuid == itemguid).Single();
                task.actorId = -1;
                task.state = "待检出";

                t_GZL_Item item = dc.t_GZL_Item.Where(i => i.itemGuid == itemguid).Single();
                item.State = "审批通过";

                t_GZL_TaskHistory history = new t_GZL_TaskHistory();
                history.actorId = task.actorId;
                history.createDate = DateTime.Now;
                history.itemGuid = item.itemGuid;
                history.memo = opinion;
                history.operatorName = operatorname;
                history.operatorUserId = operatorUserId;
                history.action = "完成";
                dc.t_GZL_TaskHistory.InsertOnSubmit(history);

                dc.SubmitChanges();
                return true;
            }
        }

        public static bool setRefuseState(Guid itemguid, String opinion, String operatorname, int operatorUserId)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                t_GZL_Item item = dc.t_GZL_Item.Where(i => i.itemGuid == itemguid).Single();
                item.State = "审批拒绝";

                t_GZL_TaskList task = dc.t_GZL_TaskList.Where(t => t.itemGuid == itemguid).Single();
              //  task.actorId = dc.t_GZL_Actor.Where(a => a.routId == 1).OrderBy(u => u.sortNo).Skip(0).Take(1).Single().actorId;


                t_GZL_TaskHistory history = new t_GZL_TaskHistory();
                history.actorId = task.actorId;
                history.createDate = DateTime.Now;
                history.itemGuid = item.itemGuid;
                history.memo = opinion;
                history.action = "拒绝";
                history.operatorName = operatorname;
                history.operatorUserId = operatorUserId;
               
                dc.t_GZL_TaskHistory.InsertOnSubmit(history);

                t_GZL_Actor actor_first = dc.t_GZL_Actor.Where(a => a.routId == item.RoutId && a.sortNo == 1).Single();
                task.actorId = actor_first.actorId;
                task.state = "待检出";

                dc.SubmitChanges();
                return true;
            }
        }
        //送审下一步执行用户的操作
        public static bool applyItem(Guid itemguid, String opinion, String operatorname, int operatorUserId,int nextOperatorId,String actorname)
        {

            try
            {
                using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
                {
                    t_GZL_Item item = dc.t_GZL_Item.Where(i => i.itemGuid == itemguid).Single();
                    t_GZL_TaskList task = dc.t_GZL_TaskList.Where(t => t.itemGuid == item.itemGuid).Single();
                    t_GZL_Actor actor = dc.t_GZL_Actor.Where(a => a.actorId == task.actorId).Single();
                    int sortNo = (int)actor.sortNo;
                    var actor_next = dc.t_GZL_Actor.Where(a => a.routId == actor.routId && a.sortNo == sortNo + 1);
                    if (actor_next.Count() != 0)//还有下一步流程
                    {
                        task.actorId = actor_next.Single().actorId;
                        item.State = "审批中"; //修改任务状态
                        t_GZL_TaskHistory history = new t_GZL_TaskHistory();//插入历史记录
                        history.actorId = actor.actorId;
                        history.createDate = System.DateTime.Now;
                        history.itemGuid = item.itemGuid;
                        history.itemId = item.ItemId;
                        history.operatorName = operatorname;
                        history.operatorUserId = operatorUserId;
                        history.memo = opinion;
                        history.action = "同意";
                        dc.t_GZL_TaskHistory.InsertOnSubmit(history);

                        var has_actuser = dc.t_GZL_actorUser.Where(u => u.actorId == task.actorId && u.itemGuid == item.itemGuid && u.operateUserId == operatorUserId && u.taskId == task.taskId);
                         if (has_actuser.Count() != null && has_actuser.Count() > 0)
                         { }
                         else//第一次申请则插入执行人，否则用原有
                         {
                             t_GZL_actorUser actUser = new t_GZL_actorUser();//插入下一步执行的人
                             actUser.actorId = task.actorId;
                             actUser.itemGuid = item.itemGuid;
                             actUser.itemId = item.ItemId;
                             actUser.operateUserId = nextOperatorId;
                             actUser.taskId = task.taskId;
                             dc.t_GZL_actorUser.InsertOnSubmit(actUser);
                         }

                        t_User_Task userTask = new t_User_Task();//插入下一步执行人的任务，用于提醒
                        userTask.description = "您有一个待审批的采购项目";
                        userTask.isClick = false;
                        userTask.url = "/Application/GZL/CG/ApplyApprove.aspx";
                        userTask.createtime = DateTime.Now;
                        userTask.userid = nextOperatorId;
                        dc.t_User_Task.InsertOnSubmit(userTask);

                        t_Form_Purchase form = dc.t_Form_Purchase.Where(f => f.itemGuid == item.itemGuid).Single();//更新表单
                        switch(actorname)
                        {
                            case "主管校长审批":
                                form.FenGuanYiJian = opinion + " " + operatorname;
                                break;
                            case "财务校长审批":
                                form.XiaoZhangYiJian = opinion + " "+operatorname;
                                break;
                        }

                        dc.SubmitChanges();
                        return true;
                    }
                    else
                        return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("送审错误：" + ex.Message);
            }
        }
        
    }
}
