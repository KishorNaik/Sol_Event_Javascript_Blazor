using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Sol_Demo.Pages.Demo
{
    public partial class ParentComponent
    {
        #region Private Property

        private ChildComponent ChildButtonComponent1 { get; set; }

        private ChildComponent ChildButtonComponent2 { get; set; }

        private double ScreenXButton1 { get; set; }

        private double ScreenXButton2 { get; set; }

        #endregion Private Property

        #region Event

        private void OnButtonClick1(MouseEventArgs e)
        {
            Debug.WriteLine(e);
            ScreenXButton1 = e.ScreenX;
            base.StateHasChanged();
        }

        private void OnButtonClick2(MouseEventArgs e)
        {
            Debug.WriteLine(e);
            ScreenXButton2 = e.ScreenX;
            base.StateHasChanged();
        }

        #endregion Event
    }
}