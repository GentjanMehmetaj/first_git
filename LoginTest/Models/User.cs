using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginTest.Models
{
    public class User
    {
        public string username { get; set; }
        public string password { get; set; }
        public int user_id { get; set; }       
        public string company_code { get; set; }
        public string last_login_company_code { get; set; }
        public string default_company_code { get; set; }
        public int? is_sales_agent { get; set; }
        public int? is_login_allowed { get; set; }
        public string mobile { get; set; }
        public int? allow_mobile_configuration { get; set; }
        public int? warehouse_id { get; set; }
        public int? cash_desk_id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string email { get; set; }
        public int? user_group_id { get; set; }
        public DateTime? xpire_date { get; set; }
        public int? address { get; set; }
        public int? view_only_own_document { get; set; }
        public int? is_customer_edit_allowed { get; set; }
        public int? is_sales_invoice_price_edit_allowed { get; set; }
        public int? is_qoutation_print_allowed { get; set; }
    }
}
