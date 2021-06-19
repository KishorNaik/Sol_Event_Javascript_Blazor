using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sol_Demo.Pages.Demo
{
    public partial class ChildComponent : IAsyncDisposable
    {
        #region Init

        #region Private Variables

        private Task<IJSObjectReference> _module = null;

        #endregion Private Variables

        #region Inject

        [Inject]
        public IJSRuntime JavascriptRuntime { get; set; }

        #endregion Inject

        #region Private Property

        private ElementReference ButtonElementReference { get; set; }

        #endregion Private Property

        #region Private Method

        private void LoadJsModules()
        {
            _module = JavascriptRuntime.InvokeAsync<IJSObjectReference>("import", "./js/main.js").AsTask();
        }

        private async Task LoadMainJs()
        {
            await (await _module).InvokeVoidAsync(identifier: "initializeCounterComponent", ButtonElementReference);
        }

        #endregion Private Method

        #endregion Init

        #region Click Event

        [Parameter]
        public Action<MouseEventArgs> OnButtonClickEventHandler { get; set; }

        //public EventCallback<MouseEventArgs> OnButtonClickEventHandler { get; set; }

        #endregion Click Event

        #region Protected Method

        protected async override Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                LoadJsModules();

                await LoadMainJs();
            }
        }

        public async ValueTask DisposeAsync()
        {
            if (_module != null)
            {
                _ = (await _module)?.DisposeAsync();
            }
        }

        #endregion Protected Method
    }
}