using System;
using System.Collections.Generic;
using System.Text;
using BusinessLayer.Interfaces;
using BusinessLayer.Levels;

namespace BusinessLayer
{
    public class BusinessManager
    {
        public IBook BooksBL()
        {
            return new BookLevel();
        }

        public IUser UserBL()
        {
            return new UserLevel();
        }
    }
}
