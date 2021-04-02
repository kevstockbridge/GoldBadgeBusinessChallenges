using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_BadgeLibrary
{
    /*A badge repository that will have methods that do the following:
    Create a dictionary of badges.
    The key for the dictionary will be the BadgeID.
    The value for the dictionary will be the List of Door Names.*/
    public class BadgeRepository
    {

        //Methods Needed: AddBadge, EditBadge - (GetBadgeByID / AddDoorAccess / RemoveDoorAccess), SeeAllBadges


     private Dictionary<int, List<string>> _badgeDict = new Dictionary<int, List<string>>();

        public void AddBadge(int badgeID, List<string> doorNames)
        {
            _badgeDict.Add(badgeID, doorNames);
        }

        public Badge GetBadgeByID(int badgeID)
        {
            Badge badge = new Badge(badgeID, _badgeDict[badgeID]);
            return badge;
        }

        public void AddDoorAccess(int badgeID, string doorID)
        {
            _badgeDict[badgeID].Add(doorID);
        }

        public void RemoveDoorAccess(int badgeID, string doorID)
        {
            _badgeDict[badgeID].Remove(doorID);
        }

        public Dictionary<int, List<string>> SeeAllBadges()
        {
            return _badgeDict;
        }

    }
}
