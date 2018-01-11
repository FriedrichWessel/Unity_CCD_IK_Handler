namespace CCDSolver
{
	public interface ICCDSolver
	{
		void AddRootNode(IIKNode rootNode);
		void AddIKTarget(ITransformNode ikTarget);
		void InsertChainObject(int chainIndex, IIKNode chainObject);
	}
}
