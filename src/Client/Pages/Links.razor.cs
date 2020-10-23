using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using MindPalace.Shared.Dtos;

namespace MindPalace.Client.Pages
{
    public partial class Links : ComponentBase
    {
        [Inject]
        public MindPalaceClient Client { get; set; }
        public List<LinkDto> StoredLinks { get; set; } = new List<LinkDto>();

        protected override async Task OnInitializedAsync()
        {
            StoredLinks = await Client.GetLinks();
        }
    }
}
