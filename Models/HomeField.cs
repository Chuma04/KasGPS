namespace KasGPS.Models
{
	public class HomeField
	{
		public Point[] HomeCoordinates { get; set; }
		public HomeField(Point[] coordinates)
		{
			if (coordinates.Length < 3) throw new Exception("This requires at least three pairs of coordinates");
			HomeCoordinates = coordinates;
		}

		public bool IsHome(Point currentLocation)
		{
			bool inside = false;
			int j = HomeCoordinates.Length - 1; // index of the last vertex
			for (int i = 0; i < HomeCoordinates.Length; i++) // loop through all vertices of the HomeCoordinates
			{
				// check if the point is on an horizontal edge of the HomeCoordinates
				if (HomeCoordinates[i].Y == currentLocation.Y && HomeCoordinates[j].Y == currentLocation.Y &&
					(HomeCoordinates[i].X >= currentLocation.X) != (HomeCoordinates[j].X >= currentLocation.X))
				{
					return true;
				}
				// check if the edge intersects with the ray
				if ((HomeCoordinates[i].Y > currentLocation.Y) != (HomeCoordinates[j].Y > currentLocation.Y) &&
					currentLocation.X < (HomeCoordinates[j].X - HomeCoordinates[i].X) * (currentLocation.Y - HomeCoordinates[i].Y) /
					(HomeCoordinates[j].Y - HomeCoordinates[i].Y) + HomeCoordinates[i].X)
				{
					inside = !inside; // toggle state
				}
				j = i; // update previous vertex index
			}
			return inside;
		}
	}
}
