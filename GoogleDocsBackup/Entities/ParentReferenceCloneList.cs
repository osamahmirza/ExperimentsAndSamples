using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentListAPI.Entities
{
    public class ParentReferenceCloneList : List<ParentReferenceClone>
    {
        public ParentReferenceCloneList(IList<Google.Apis.Drive.v2.Data.ParentReference> pr)
        {
            if (pr != null && pr.Count > 0)
            {
                foreach (var item in pr)
                {
                    this.Add(new ParentReferenceClone()
                    {
                        ETag = item.ETag,
                        Id = item.Id,
                        IsRoot = item.IsRoot,
                        Kind = item.Kind,
                        ParentLink = item.ParentLink,
                        SelfLink = item.SelfLink
                    });
                    
                }
            }
        }
    }
}