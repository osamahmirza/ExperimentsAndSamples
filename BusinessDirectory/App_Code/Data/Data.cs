using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoProGo.Data
{
    public static class GoProGoDC
    {
        private static ProfileDataContext _ProfileDC;
        public static ProfileDataContext ProfileDC
        {
            get
            {
                if (_ProfileDC == null)
                {
                    _ProfileDC = new ProfileDataContext() { ObjectTrackingEnabled = true };
                }
                return _ProfileDC;
            }
        }

        private static GeoDataContext _GeoDC;
        public static GeoDataContext GeoDC
        {
            get
            {
                if (_GeoDC == null)
                {
                    _GeoDC = new GeoDataContext() { ObjectTrackingEnabled = true };
                }
                return _GeoDC;
            }
        }

        private static FileDataContext _FileDC;
        public static FileDataContext FileDC
        {
            get
            {
                if (_FileDC == null)
                {
                    _FileDC = new FileDataContext() { ObjectTrackingEnabled = true };
                }
                return _FileDC;
            }
        }

        private static SearchDataContext _SearchDC;
        public static SearchDataContext SearchDC 
        {
            get
            {
                if (_SearchDC == null)
                {
                    _SearchDC = new SearchDataContext() { ObjectTrackingEnabled = false};
                }
                return _SearchDC;
            }
        }
    }
}
