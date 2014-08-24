using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BLL.Application.GZL.CG
{
    public class PurchaseFormEdit
    {
        public static bool updatePurchaseFormItems(int id,String type,float price,int number)
        {
            using (DataClassesEduDataContext dc = new DataClassesEduDataContext())
            {
                try
                {
                    t_Form_Purchase_Items item = dc.t_Form_Purchase_Items.Where(i => i.Id == id).Single();
                    t_Form_Purchase form = dc.t_Form_Purchase.Where(f => f.formId == item.formId).Single();
                    item.type = type;
                    item.price = price;
                    item.number = number;
                    item.totalPrice = price * number;
                    form.totalPrice = dc.t_Form_Purchase_Items.Where(t => t.formId == item.formId).Sum(z => z.totalPrice);
                    dc.SubmitChanges();
                    return true;
                }catch (Exception e)
                {
                    throw e;
                }
            }
        }
    }
}
