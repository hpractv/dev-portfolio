<Query Kind="Program">
  <Namespace>analyticsLibrary.dbObjects</Namespace>
  <Namespace>analyticsLibrary.library</Namespace>
</Query>

[Flags]
public enum projectDifficulty {
	easy = 0,
	medium = 1,
	difficult = 2,
	shouldNotBeAttempted = 4
};

public class project
{
	public projectDifficulty DifficultyRating { get; set; }

	public string Name { get; set; }

	public int? HoursEstimated { get; set; }
}


public static void Main()
{
	var saveTheWorld = new project { Name = "Save The World", DifficultyRating = projectDifficulty.difficult };

	//calculate hours for the project
	switch (saveTheWorld.DifficultyRating)
	{
		case (projectDifficulty.easy):
			saveTheWorld.HoursEstimated = 6;
			break;
		case (projectDifficulty.medium):
			saveTheWorld.HoursEstimated = 12;
			break;
		case (projectDifficulty.difficult):
			saveTheWorld.HoursEstimated = 24;
			break;
		case (projectDifficulty.shouldNotBeAttempted):
		default:
			saveTheWorld.HoursEstimated = (int?)null;
			break;
	}

	Console.WriteLine("'{0}' hours estimated: {1}", saveTheWorld.Name, saveTheWorld.HoursEstimated);

	//Output
	//'Save The World' hours estimated: 24
		
	var canWorkOn = projectDifficulty.easy | projectDifficulty.medium | projectDifficulty.difficult;
	if(canWorkOn.HasFlag(saveTheWorld.DifficultyRating))
		Console.WriteLine("We can work on this.");
	else
		Console.WriteLine("This is not something we should attempt.");
		
	//Output
	//We can work on this.
		
}