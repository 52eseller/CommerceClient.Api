using System.Collections.Generic;
using CommerceClient.Api.Model.JsonConverters;
using Newtonsoft.Json;

namespace CommerceClient.Api.Model.ResponseModels.Menu
{
    public class MenuItem
    {
        [JsonConverter(typeof(MenuKeyConverter))]
        public MenuKey MenuKey { get; set; }
        [JsonConverter(typeof(MenuKeyConverter))]
        public MenuKey? ParentMenuKey { get; set; }
        public string ExtMenuItemId { get; set; }
        public string Bookmark { get; set; }
        public int SortOrder { get; set; }
        public string NavigateUrl { get; set; }
        public string NavigateTarget { get; set; }
        public int? PageFlowId { get; set; }
        public int? PageFlowSortOrder { get; set; }
        public TreeBranchContent? RootEntry { get; set; }
        public string LifeTimeId { get; set; }
        public string Name { get; set; }

        public List<ResourceLink> Links { get; set; }

    }
}
