using System;
using System.Collections.Generic;
namespace WebAPI.model
{
    public class Allresult
    {
         public List<resultlist> allresultdetail { get; set; }
        public Allresult()
        {
        }

        public Allresult(List<resultlist> allresultdetail)
        {
            this.allresultdetail = allresultdetail;
        }

       
    }
  
    
 
}
