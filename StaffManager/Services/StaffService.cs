using StaffManager.Models;

namespace StaffManager.Services
{
    public class StaffService
    {
        private List<StaffMember> staffMembers = new List<StaffMember>();

        public void AddStaff(StaffMember staff)
        {
            staffMembers.Add(staff);
        }

        public List<StaffMember> GetAllStaff()
        {
            return staffMembers;
        }

        public StaffMember GetStaffById(int staffId)
        {
            foreach (StaffMember staff in staffMembers)
            {
                if (staff.StaffId == staffId)
                {
                    return staff;
                }
            }

            return null;
        }

        public void UpdateStaff(StaffMember updatedStaff)
        {
            StaffMember existingStaff = GetStaffById(updatedStaff.StaffId);

            if (existingStaff != null)
            {
                existingStaff.FullName = updatedStaff.FullName;
                existingStaff.Email = updatedStaff.Email;
                existingStaff.Position = updatedStaff.Position;
                existingStaff.Unit = updatedStaff.Unit;
            }
        }

        public void DeleteStaff(int staffId)
        {
            StaffMember staff = GetStaffById(staffId);

            if (staff != null)
            {
                staffMembers.Remove(staff);
            }
        }
    }
}
    

