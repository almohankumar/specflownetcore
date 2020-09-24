using SpecflowNetCoreDemo.Pages;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecflowNetCoreDemo.Base
{
    public abstract class BasePage : Base
    {
        public BasePage(Page page) : base(page)
        {
        }
    }
}
