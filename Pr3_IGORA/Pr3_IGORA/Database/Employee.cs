//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Pr3_IGORA.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class Employee
    {
        public int IDEmployee { get; set; }
        public Nullable<int> IDPost { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public Nullable<System.DateTime> last_entry { get; set; }
    
        public virtual Post Post { get; set; }
    }
}
