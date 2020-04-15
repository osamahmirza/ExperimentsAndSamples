using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentListAPI.Entities
{
    public class UserReferenceCloneList : List<UserReferenceClone>
    {
        public UserReferenceCloneList(IList<Google.Apis.Drive.v2.Data.User> usr)
        {
            if (usr != null && usr.Count > 0)
            {
                foreach (var item in usr)
                {
                    this.Add(new UserReferenceClone()
                    {
                        DisplayName = item.DisplayName,
                        IsAuthenticated = item.IsAuthenticatedUser,
                        Kind = item.Kind,
                        PermissionId = item.PermissionId,
                        PictureUrl = item.Picture != null ? item.Picture.Url : null
                    });
                    
                }
            }
        }
    }
}