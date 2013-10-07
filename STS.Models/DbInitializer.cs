using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace STS.Models
{
    public class DbInitializer : DropCreateDatabaseIfModelChanges<DataContext>
    {

    }
}
