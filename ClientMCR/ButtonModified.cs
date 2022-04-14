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
        int EntityIDField;

        public void SetEntityIDField(int IntCompanyIDField)
        {
            EntityIDField = IntCompanyIDField;
        }

        public int GetEntityIDField()
        {
            return EntityIDField;
        }

        public string GetEntityIDFieldString()
        {
            try
            {
                return EntityIDField.ToString();
            }
            catch (Exception e)
            {
                //better method for exeption handling maybe needed here
                return string.Empty;
            }
        }
    }
}
