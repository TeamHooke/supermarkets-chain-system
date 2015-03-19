using SQLData;

namespace ExportSQLDBToMySQlDB
{
    //using System.ComponentModel.DataAnnotations.Schema;

    //[Table("Products")]
    public class MySqlProduct : Product
    {
        public decimal Income { get; set; }
    }
}
