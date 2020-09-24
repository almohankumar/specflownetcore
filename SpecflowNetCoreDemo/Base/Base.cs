using SpecflowNetCoreDemo.Pages;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecflowNetCoreDemo.Base
{
    public class Base
    {
        public readonly Page _page;
        public Base(Page page)
        {
            _page = page;
        }

      
        public TPage As<TPage>() where TPage : BasePage
        {
              return (TPage)this;
        }
    }


}
