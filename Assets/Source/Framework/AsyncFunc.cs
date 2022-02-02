using System.Threading.Tasks;

namespace UIArchitecture
{
    public delegate Task AsyncAction<in T>(T value);
}