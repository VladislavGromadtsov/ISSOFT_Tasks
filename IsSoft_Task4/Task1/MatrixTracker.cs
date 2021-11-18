namespace Task1
{
    public class MatrixTracker<T>
    {
        private T _prev, _new;
        private int index;
        private DiagonalMatrix<T> diagMatrix;
        public MatrixTracker(DiagonalMatrix<T> matrix)
        {
            diagMatrix = matrix;
            matrix.ElementChanged += Matrix_ElementChanged;
        }

        private void Matrix_ElementChanged(object sender, ElementChangedEventArgs<T> e)
        {
            (index, _prev, _new) = (e.Index, e.Old, e.New);
        }

        public void Undo()
        {
            diagMatrix[index, index] = _prev;
        }
    }
}