﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Application.KQ.Attendance
{
    public class MyApproval
    {
        public static List<v_KQ_Attendance> getMyApprovalRecord(int approvalId, int index, int num, ref int tot)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                tot = dc.v_KQ_Attendance.Where(u => u.ApprovalId == approvalId).Count();
                var r = dc.v_KQ_Attendance.Where(u => u.ApprovalId == approvalId).OrderByDescending(o => o.Id).Skip(index).Take(num);
                return r.ToList();
            }
        }


        public static List<v_KQ_Attendance_History> getMyApprovalHistoryRecord(int approvalHistoryId, int index, int num, ref int tot)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                tot = dc.v_KQ_Attendance_History.Where(u => u.approvalHistoryId == approvalHistoryId).Count();
                var r = dc.v_KQ_Attendance_History.Where(u => u.approvalHistoryId == approvalHistoryId).OrderByDescending(o => o.Id).Skip(index).Take(num);
                return r.ToList();
            }
        }



        public static bool setAttendanceApplyStatus(int id, int result, int approvalUserId, String reason = "") //result:1同意0拒绝
        {
            String tel = "";
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                dc.AttendanceApprovalSubmit(id, result, ref tel);

                if(!String.IsNullOrEmpty(reason))
                {
                    var history = dc.KQ_AttendanceApprovalHistory.Where(h => h.attendanceId == id && h.userid == approvalUserId);
                    if(history.Count()==1)
                    {
                        KQ_AttendanceApprovalHistory h = history.Single();
                        h.reason = reason;
                        dc.SubmitChanges();
                    }
                }
                if (!String.IsNullOrEmpty(tel))
                {
                    v_KQ_Attendance kq = dc.v_KQ_Attendance.Where(u => u.Id == id).Single();
                    string approvalyes="http://wx.nbyzzj.cn/approval.php?attendId="+id+"%26result=1%26approvalId="+kq.ApprovalId;
                    string approvalno = "http://wx.nbyzzj.cn/approval.php?attendId=" + id + "%26&result=0";

                    string message = "您有一条待审批的请假申请，请假人：" + kq.username + " ，请假类型：" + kq.applytype + "，请假时间从：" + kq.starttime.ToString() + "到：" + kq.endtime.ToString() + ",事由：" + kq.reason + ",请您审批，(不同意需在电脑审批)同意点以下链接：" + approvalyes;
                    //+"。不同意点：" + approvalno;
                    //tel = "13486689106";
                    BLL.pub.PubClass.sendSMS(tel, message);
                }
                return true;
                /*
                KQ_Attendance kq = dc.KQ_Attendance.Where(o => o.Id == id).Single();

                if (kq.stepNow == kq.stepCount)
                {
                    kq.status = status;

                    Users user = dc.Users.Where(u => u.Key == kq.userid).Single();
                    string message = "您的请假申请已处理，审批人：" + kq.ApprovalName + " 审批结果：" + status;
                    if (!String.IsNullOrEmpty(user.changhao))
                        BLL.pub.PubClass.sendSMS(user.changhao, message);
                }else
                {
                    kq.stepNow += 1;
                    kq.status = "审批中";

                    int headmasterId = (int)dc.Department.Where(d => d.Name == kq.dept).Single().HeadmasterId;
                    Users user = dc.Users.Where(u => u.Key == headmasterId).Single();
                    String headmasterName = user.TrueName;
                    kq.ApprovalId = headmasterId;
                    kq.ApprovalName = headmasterName;

                    t_User_Task task = new t_User_Task();
                    task.createtime = kq.applyTime;
                    task.url = "/Application/KQ/Attendance/MyApproval.aspx";
                    task.description = "您有一条请假申请待审批";
                    task.isClick = false;
                    dc.t_User_Task.InsertOnSubmit(task);

                     string message = "您有一条待审批的请假申请：" + kq.username + " " + kq.reason; 
                     if(!String.IsNullOrEmpty(user.changhao))
                       BLL.pub.PubClass.sendSMS(user.changhao, message);
                }
                dc.SubmitChanges();
                return true;
                 * */
            }
        }
    }
}
