using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
namespace TooSharp.Models
{   
    /// <summary>
    ///  TooSharp Generated Code. Do not Modify 
    ///  Date Genereated: 12/7/2019 3:01 PM
    ///  Author: kira0
    /// </summary>
    /// <seealso cref="TooSharp.Core.ITSRelationShips" />
    [DebuggerStepThrough]
    public class Productos : TooSharp.Core.ITSModel
    {
      #region CODE
	     public static string TableName = "productos";
         public string GetTableName() { return TableName; }
         public List<string> GetColumns() {return Enum.GetValues(typeof(COLUMNS)).Cast<COLUMNS>().Select(v => v.ToString()).ToList();  }
         public static TooSharp.Core.TSQueryBuilder<Producto> Records() { return new TooSharp.Core.TSQueryBuilder<Producto>(TooSharp.TSRelationships.getInstance()); }
         public static TooSharp.Core.TSQueryBuilder<Producto> Records(object[] columns) { return new TooSharp.Core.TSQueryBuilder<Producto>(TooSharp.TSRelationships.getInstance(),columns); }
      #endregion
      #region COLUMNS
       public enum COLUMNS
       {
         id_producto,
         nombre,
         precio,
         //column
       }
      #endregion
    }
     [DebuggerStepThrough]
    public class Producto: TooSharp.Core.TSmodel 
    {
     
       #region PROPERTIES
         [TSKey]
         public int Id_producto { get; private set; }=-1;
         [TSNotEmpty]
         public string Nombre { get; set; }
         [TSNotEmpty]
         public string Precio { get; set; }
         //property
       #endregion
    }
}
