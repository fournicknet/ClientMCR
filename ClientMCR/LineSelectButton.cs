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
    public partial class LineSelectButton : Button
    {
        int CompanyEntityIDField, ContactEntityIDField, rowSpread, columnSpread;
        bool isLineSelectMouseOver = false;

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

        public void SetRowSpread(int rowSpreadProvided)
        {
            rowSpread = rowSpreadProvided;
        }

        public int GetRowSpread()
        {
            return rowSpread;
        }

        public void SetColumnSpread(int columnSpreadProvided)
        {
            columnSpread = columnSpreadProvided;
        }

        public int GetColumnSpread()
        {
            return columnSpread;
        }

        public void SetIsLineSelectedMouseOver(bool isSelected)
        {
            isLineSelectMouseOver = isSelected;
        }

        public bool GetIsLineSelectedMouseOver()
        {
            return isLineSelectMouseOver;
        }
        protected override void OnMouseEnter(MouseEventArgs e)
        {
            base.OnMouseEnter(e);

        }


        //protected override void OnMouseEnter(MouseEventArgs e)
        //{
        //    base.OnMouseEnter(e);

        //}
    }
}
