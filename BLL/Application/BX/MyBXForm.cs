using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace BLL.Application.BX
{
    public class MyBXForm
    {
        public  List<t_BX_PositionType>  getDDLPositionType()
        {
            var list = new t_BX_PositionType_Repository().LoadAll();
            return list.ToList();
        }

        public  List<t_BX_Position> getDDLPosition(int positionTypeId)
        {
            var list = new t_BX_Position_Repository().LoadWhere(t => t.PositionTypeId == positionTypeId);
            return list.ToList();
        }

        public  bool saveForm(t_BX_Form form)
        {
            bool result = new t_BX_Form_Repository().Save(form);
            return result;
        }

        public  bool DeleteFormItem(int Id)
        {
           return new t_BX_FormItem_Repository().Delete(Id);
        }

        public  List<t_BX_Form> getForms(int userid, int index, int num, ref int tot)
        {

            tot = new t_BX_Form_Repository().LoadWhere(f => f.userid == userid).Count();
            var list = new t_BX_Form_Repository().LoadWhere(f => f.userid == userid).OrderByDescending(o=>o.Id).Skip(index).Take(num);
            return list.ToList();
        }


        public  List<t_BX_FormItem> getFormItems(int formId)
        {
             List<t_BX_FormItem> Lists = new t_BX_FormItem_Repository().LoadWhere(f => f.FormId == formId);
            return Lists.OrderBy(o=>o.Date).ToList();
        }

        public  bool saveFormItem(int formId, t_BX_FormItem item)
        {
            t_BX_Form form = new t_BX_Form_Repository().Load(formId);

            if (item.AccommodationFee / item.Days / item.PeoplesNum > 340)
            {
                throw new Exception("住宿费每人每天不得超过340元，超出部分请自行解决，请重新填写！");
            }
            item.Allowance = 0;
            switch (form.PositionTypeId)
            {
                case 1: //中心区10
                    if (item.TrafficFee / item.Days / item.PeoplesNum > 10)
                        throw new Exception("中心区交通费每人每天不超10元，超出部分请自行解决，请重新填写！");
                    if(!item.IsReception)
                        item.Allowance = item.PeoplesNum * item.Days * 40;
                    break;
                case 2://近郊20
                    if (item.TrafficFee / item.Days / item.PeoplesNum > 20)
                        throw new Exception("近郊交通费每人每天不超20元，超出部分请自行解决，请重新填写！");
                    if(!item.IsReception)
                        item.Allowance = item.PeoplesNum * item.Days * 40;
                    break;
                case 3://市内40
                    if (item.TrafficFee / item.Days / item.PeoplesNum > 40)
                        throw new Exception("市内交通费每人每天不超40元，超出部分请自行解决，请重新填写！");
                    if(!item.IsReception)
                        item.Allowance = item.PeoplesNum * item.Days * 40;
                    break;
                default:
                    if (item.TrafficFee / item.Days / item.PeoplesNum > 80)
                        throw new Exception("宁波以外城市内交通费每人每天不超80元，超出部分请自行解决，请重新填写！");
                    if(!item.IsReception)
                         item.Allowance = item.PeoplesNum * item.Days * 100;
                    break;
            }

            return new t_BX_FormItem_Repository().Save(item);

        }
    }
}
