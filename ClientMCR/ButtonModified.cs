using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ClientMCR
{
    public partial class ButtonModified : Button
    {
        int CompanyEntityIDField, ContactEntityIDField;

        public void SetCompanyEntityIDField(int IntCompanyIDField)
        {
            CompanyEntityIDField = IntCompanyIDField;
        }

        public int GetEntityIDField()
        {
            return CompanyEntityIDField;
        }

        public string GetEntityIDFieldString()
        {
            try
            {
                return CompanyEntityIDField.ToString();
            }
            catch (Exception e)
            {
                //better method for exeption handling maybe needed here
                return string.Empty;
            }
        }

        public void SetContactEntityIDField(int IntContactEntityIDField)
        {
            ContactEntityIDField = IntContactEntityIDField;
            //int.TryParse(StringCompanyIDField, out CompanyEntityID);
        }

        public int GetContactEntityIDField()
        {
            return ContactEntityIDField;
        }

        public string GetContactEntityIDFieldString()
        {
            return ContactEntityIDField.ToString();
        }

        //protected override void OnMouseEnter(MouseEventArgs e)
        //{
        //    base.OnMouseEnter(e);

        //}
    }
}
