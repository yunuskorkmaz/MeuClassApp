using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuClass.Data
{
    public class ContextConfig : CreateDatabaseIfNotExists<ClassAppContext>
    {
        public ContextConfig()
        {
        }

        protected override void Seed(ClassAppContext context)
        {
            context.UserType.AddRange(new UserType[] {
                new UserType(){UserTypeName = "Admin" , UserTypeID =1},
                new UserType(){UserTypeName = "Teacher" , UserTypeID =2},
                new UserType(){UserTypeName = "Student" , UserTypeID =3 }
            });

            context.SaveChanges();
           
            base.Seed(context);
        }
    }
}
