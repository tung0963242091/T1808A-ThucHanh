using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thuchanh.Entity;
using Thuchanh.Utils;

namespace Thuchanh.Models
{
    class ContactModel
    {

        public bool Insert(Contact note)
        {
            try
            {
                using (var statement = SQLiteUtil.GetInstances().Connection.Prepare("INSERT INTO Note (Name, PhoneNumber) VALUES (?, ?)"))
                {
                    statement.Bind(1, note.Name);
                    statement.Bind(2, note.PhoneNumber);
                    statement.Step();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return false;
        }

    }
}
