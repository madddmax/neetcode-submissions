public class DynamicArray {
    int _capacity;
    int _size;
    int[] _arr;


    public DynamicArray(int capacity) {
        _capacity = capacity;
        _size = 0;
        _arr = new int[capacity];
    }

    public int Get(int i) {
        return _arr[i];
    }

    public void Set(int i, int n) {
        _arr[i] = n;
    }

    public void PushBack(int n) {
        if(_size == _capacity)
        {
            Resize();
        }

        _arr[_size] = n;
        _size++;
    }

    public int PopBack() {
        _size--;
        return _arr[_size];
    }

    private void Resize() {
        _capacity = _capacity * 2;
        var newArray = new int[_capacity];
        for(int i = 0; i < _size; i++)
        {
            newArray[i] = _arr[i];
        }

        _arr = newArray;
    }

    public int GetSize() {
        return _size;
    }

    public int GetCapacity() {
        return _capacity;
    }
}
