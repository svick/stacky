using System.Collections.Generic;
using Newtonsoft.Json;

namespace Stacky
{
    public class AssociatedUsersResponse
    {
        [JsonProperty("associated_users")]
        public List<AssociatedUser> Users { get; set; }
    }
}