using Core;
using Meteor.Models;

namespace Meteor
{
    public interface IMeteorComponent : IGameEntityComponent<MeteorModel>
    {
        MeteorModel MeteorModel { set; get; }
    }
}