using System;
using System.Collections.Generic;
using System.Text;

namespace Camoran.Japper.Operation
{

    public enum OperatorType
    {
        Equal=1,
        NotEqual=2,
        LessThan=3,
        LessThanOrEqual=4,
        MoreThan=5,
        MoreThanOrEqual=6,
        In=7,
        NotIn=8,
        Between=9,
        NotBetween=10
    }

}


//[Table()]
//public class A
//{
//    [StringColumn]
//    public string A { get; set; }

//    puc
//    //public List<StringColumn> B { get; set; }

   
//}
 

//生成: 

//partial class Table A
//{
//    public stringCoulmn A { }

//    public stringCoulmn B { }
//}

//partial class Table A 
//    {
//    public List<StringColumn> B { get; set; }
//    }



//"insert into A values (1,2,3,45,)"


//"select A.b,A.c,A.d from A where b.notIn(1,2,3,45,6)"