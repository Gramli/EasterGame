using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace EasterGame.Class
{
    class HerniObjekt
    {   //X a Y pozice obejktu
        public virtual int X
        {
            get;
            set;
        }
        public virtual int Y
        {
            get;
            set;
        }
        //obrazek
        public Image ObrazekObjektu
        {
            get;
            set;
        }
        //konstrukor
        public HerniObjekt(int poziceX,int poziceY)
        { 
        
        }
        //vykresluje
        public virtual void VykresliObjekt(Graphics g)
        {
            
        }
        //pro hrace
        public virtual void VstupHrace(System.Windows.Forms.Keys key)
        { 
            
        }


    }
}
