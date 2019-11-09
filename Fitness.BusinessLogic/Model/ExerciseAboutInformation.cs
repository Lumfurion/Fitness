using System;
namespace Fitness.BusinessLogic.Model
{
    [Serializable]
    public class ExerciseAboutInformation
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string VideoGirl { get; set; }
        public string VideoMan { get; set; }

        public ExerciseAboutInformation(string name, string description, string image, string videoGirl, string videoMan)
        {
            Name = name;
            Description = description;
            Image = image;
            VideoGirl = videoGirl;
            VideoMan = videoMan;
        }
        
    }
}
