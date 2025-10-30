using Application.DTOs.Responses;
using Application.DTOs.Secondary;
using Application.Interfaces.ForRepositories;
using Application.Interfaces.ForServices;
using Domain;
using Microsoft.Extensions.Logging;

namespace Application.Services
{
    public class GroupService : IGroupService
    {
        IGroupRepositorie _groupRepositorie;
        IStudentRepositorie _studentRepositorie;
        ICourseRepositorie _courseRepositorie;

        ILogger<GroupService> _logger;

        public GroupService(
            IGroupRepositorie groupRepositorie,
            IStudentRepositorie studentRepositorie,
            ICourseRepositorie courseRepositorie,
            ILogger<GroupService> logger)
        {
            _groupRepositorie = groupRepositorie;
            _studentRepositorie = studentRepositorie;
            _courseRepositorie = courseRepositorie;
            _logger = logger;
        }

        public async Task<GetGroupsResponse> GetGroupsAsync(int courseId)
        {
            List<ParticularGroup> particularGroups = new List<ParticularGroup>();

            List<Group> groupsByCourseId = await _groupRepositorie.GetGroupsByCourseIdAsync(courseId);

            List<Student> students = await _studentRepositorie.GetAllStudentsAsync();

            for (int i = 0; i < groupsByCourseId.Count; i++)
            {
                particularGroups[i].Id = groupsByCourseId[i].Id;

                List<int> memberIds = new List<int>();

                for (int j = 0; j < students.Count(); j++)
                {
                    if (students[0].GroupId == groupsByCourseId[i].Id)
                    {
                        particularGroups[i].MembersIds.Add(students[0].Id);
                    }
                }
            }

            GetGroupsResponse getGroupsResponse = new GetGroupsResponse()
            {
                Id = courseId,
                Groups = particularGroups
            };

            return getGroupsResponse;
        }

        public async Task AddStudentInGroupAsync(Student student)
        {
            int courseId = student.CourseId;

            StudentEnrollment studentEnrollment = await _studentRepositorie.GetStudentEnrollmentAsync(courseId);

            List<Group> courseGroups = await _groupRepositorie.GetGroupsByCourseIdAsync(courseId);

            List<Student> courseStudents = await _studentRepositorie.GetStudentsByCourseIdAsync(courseId);

            for (int i = 0; courseGroups.Count > 0; i++)
            {
                for (int j = 0; j < courseStudents.Count; j++)
                {
                    if (studentEnrollment.PreferredPeerIds.Contains(courseStudents[j].Id) && !studentEnrollment.BlacklistedPeerIds.Contains(courseStudents[j].Id))
                    {
                        student.GroupId = i;

                        return;
                    }
                }
            }

            for (int i = 0; courseGroups.Count > 0; i++)
            {
                for (int j = 0; j < courseStudents.Count; j++)
                {
                    if (!studentEnrollment.BlacklistedPeerIds.Contains(courseStudents[j].Id))
                    {
                        student.GroupId = i;

                        return;
                    }
                }
            }

           await AddStudentInNewGroupAsync(student);
        }

        private async Task AddStudentInNewGroupAsync(Student student)
        {
            List<Group> groups = await _groupRepositorie.GetAllGroupsAsync();

            List<Course> courses = await _courseRepositorie.GetAllCoursesAsync();

            if (courses.Find(x => x.Id == student.CourseId).MaxGroupSize > groups.Count)
            {
                int groupId = await _groupRepositorie.AddGroupAsync(new Group { CourseId = student.CourseId });

                student.GroupId = groupId;
            }
            else
            {
                throw new Exception("Максимальное число групп!");
            }
        }
    }
}