class Tree<T>
{
    private TreeNode<T> root = null;
    private int length = 0;

    public void AddSibling(T index, T value)
    {
        TreeNode<T> node = new TreeNode<T>(value);
        TreeNode<T> ptr = this.GetTreeNode(index);
        node.SetNext(ptr.Next());
        ptr.SetNext(node);
        node.Setcaptain(ptr.Captain());
        this.length++;
    }

    public void AddChild(T index, T value)
    {
        TreeNode<T> node = new TreeNode<T>(value);
        if(length == 0)
        {
            node.SetChild(this.root);
            this.root = node;
        }
        else
        {
            TreeNode<T> ptr = this.GetTreeNode(index);
            node.SetChild(ptr.Child());
            node.Setcaptain(ptr);
            ptr.SetChild(node);
        }
        this.length++;
    }

    public int GetLength()
    {
        return this.length;
    }

    public T Get(T index)
    {
        TreeNode<T> ptr = this.GetTreeNode(index);
        return ptr.GetValue();
    }

    private TreeNode<T> GetTreeNode(T index)
    {
        return this.Search(index);
    }

    private TreeNode<T> Traverse(TreeNode<T> currentTreeNode, ref int traverseStep)
    {
        TreeNode<T> ptr = currentTreeNode;

        if(traverseStep > 0 && currentTreeNode.Child() != null)
        {
            traverseStep--;
            ptr = this.Traverse(currentTreeNode.Child(), ref traverseStep);
        }

        if(traverseStep > 0 && currentTreeNode.Next() != null)
        {
            traverseStep--;
            ptr = this.Traverse(currentTreeNode.Next(), ref traverseStep);
        }

        return ptr;
    }

     public T Get(int index)
    {
        TreeNode<T> ptr = this.GetTreeNode(index);
        return ptr.GetValue();
    }

    public TreeNode<T> GetTreeNode(int index)
    {
        int traverseStep = index;
        return this.Traverse(this.root, ref traverseStep);
    }
    
    public Queue<T> Showcaptain(T value){
        TreeNode<T> showcaptain = GetTreeNode(value);
        Queue<T> queueshowcaptain = new Queue<T>();

        while(true){
            T nani = showcaptain.Captain().GetValue();
            queueshowcaptain.Push(nani);
            showcaptain = showcaptain.Captain();
            if(showcaptain.Captain() == null ){
                break;
            }
        }
        return queueshowcaptain;
    }
    private TreeNode<T> Search(T value)
    {
        Queue<TreeNode<T>> nodeQueue = new Queue<TreeNode<T>>();
        nodeQueue.Push(this.root);

        TreeNode<T> ptr;
        while(nodeQueue.GetLength() > 0)
        {
            ptr = nodeQueue.Pop();
            if(ptr.GetValue().Equals(value))
            {
                return ptr;
            }
            else
            {
                if(ptr.Child() != null)
                {
                    nodeQueue.Push(ptr.Child());
                }
                if(ptr.Next() != null)
                {
                    nodeQueue.Push(ptr.Next());
                }
            }
        }

        return null;
    }
}