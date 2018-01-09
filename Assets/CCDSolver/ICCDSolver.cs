namespace CCDSolver
{
	public interface ICCDSolver
	{
		void AddRootNode(IIKNode rootNode);
		void AddIKTarget(IIKNode ikTarget);
		void InsertChainObject(int chainIndex, IIKNode chainObject);
	}
}
