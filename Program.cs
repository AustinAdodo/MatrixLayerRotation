namespace MatrixLayerRotation
{
    internal class Program
    {
        //Circular Array Rotation.
        public static List<int> circularArrayRotation(List<int> a, int k, List<int> queries)
        {
            List<int> result = new List<int>();
            k = k % a.Count;
            for (int i = 0; i < queries.Count; i++)
            {
                result.Add(a[(a.Count - k + queries[i]) % a.Count]);
            }
            return result;
        }

        //Matrix layer rotation..
        public static void matrixRotation(List<List<int>> matrix, int r)
        {
            //List<List<int>>  to int[][]
            //List<List<int>>  to int[,]
            // int[][] to List<List<int>>  
            //int[,] to int [][]
            int[,] result = new int[matrix.Count, matrix[0].Count];

            for (int i = 0; i < Math.Min(matrix.Count / 2, matrix[0].Count / 2); i++)
            {
                int columnSize = matrix.Count - (i * 2); // row boundary
                int rowSize = matrix[0].Count - (i * 2); // column boundary

                // linearize each layer
                int index = 0;
                List<int> lin = new List<int>();
                int j = i;
                int k = (i + 1);
                while (j < (i + columnSize)) lin.Add(matrix[j++][i]); // left column
                j--;
                while (k < (i + rowSize)) lin.Add(matrix[j][k++]); // bottom row
                k--;
                j--;
                while (j >= i) lin.Add(matrix[j--][k]); // right column
                j++;
                k--;
                while (k > i) lin.Add(matrix[j][k--]); // top row

                // rotate the linearized inner layer
                int[] rotated = new int[lin.Count];
                for (int l = 0; l < lin.Count; l++) rotated[l] = lin[(rotated.Length - (r % rotated.Length) + l) % rotated.Length];

                // insert back into original matrix
                j = i;
                k = (i + 1);
                index = 0;
                while (j < (i + columnSize)) matrix[j++][i] = rotated[index++]; // left column
                j--;
                while (k < (i + rowSize)) matrix[j][k++] = rotated[index++]; // bottom row
                k--;
                j--;
                while (j >= i) matrix[j--][k] = rotated[index++];// right column
                j++;
                k--;
                while (k > i) matrix[j][k--] = rotated[index++]; // top row
            }
            foreach (List<int> row in matrix) Console.WriteLine(string.Join(" ", row));
        }

        //Using jagged Array
        public static void matrixRotation1(int[][] matrix, int r)
        {
            //int[,] result = new int[matrix.Length, matrix[0].Length];

            for (int i = 0; i < Math.Min(matrix.Length / 2, matrix[0].Length / 2); i++)
            {
                int columnSize = matrix.Length - (i * 2); // row boundary
                int rowSize = matrix[0].Length - (i * 2); // column boundary

                // linearize each layer
                int index = 0;
                List<int> lin = new List<int>();
                int j = i;
                int k = (i + 1);
                while (j < (i + columnSize)) lin.Add(matrix[j++][i]); // left column
                j--;
                while (k < (i + rowSize)) lin.Add(matrix[j][k++]); // bottom row
                k--;
                j--;
                while (j >= i) lin.Add(matrix[j--][k]); // right column
                j++;
                k--;
                while (k > i) lin.Add(matrix[j][k--]); // top row

                // rotate the linearized inner layer
                int[] rotated = new int[lin.Count];
                for (int l = 0; l < lin.Count; l++) rotated[l] = lin[(rotated.Length - (r % rotated.Length) + l) % rotated.Length];

                // insert back into original matrix
                j = i;
                k = (i + 1);
                index = 0;
                while (j < (i + columnSize)) matrix[j++][i] = rotated[index++]; // left column
                j--;
                while (k < (i + rowSize)) matrix[j][k++] = rotated[index++]; // bottom row
                k--;
                j--;
                while (j >= i) matrix[j--][k] = rotated[index++];// right column
                j++;
                k--;
                while (k > i) matrix[j][k--] = rotated[index++]; // top row
            }
            foreach (int[] row in matrix) Console.WriteLine(string.Join(" ", row));
        }
        static void Main(string[] args)
        {
            // => 90 degree roation r = 2, 180 degree r = 4.
            List<List<int>> tester = new();
            tester.Add(new List<int>() { 1, 2, 3 });
            tester.Add(new List<int>() { 4, 5, 6 });
            tester.Add(new List<int>() { 7, 8, 9 });
            matrixRotation(tester,2);
            Console.Write("\n \n");

            int[][] anotherTestarr = new int[3][];
            anotherTestarr[0] = new int[] { 1, 2, 3 };
            anotherTestarr[1] = new int[] { 4, 5, 6 };
            anotherTestarr[2] = new int[] { 7, 8, 9 };
            matrixRotation1(anotherTestarr, 4);
        }
    }
}