namespace graphical_artifact_comparer
{
    public class PixelComparer
	{
        public int Compare(IEnumerable<string> a, IEnumerable<string> b) {
            int artifacts = 0;
            
            for(int i = 0; i < a.Count(); i++){
                if (a.ElementAt(i) != b.ElementAt(i)) {
                    artifacts++;
                }
            }

            return artifacts;
            // return a.AsParallel().Except(b.AsParallel()).Count();
        } 
    }
}

