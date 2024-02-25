using Spix.Application.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spix.Application.Spixers.Like;

public class LikeASpixerCommand  : ICommandBase<LikeASpixerResponse>    
{
    public Guid UserId { get; set; }
    public Guid SpixerId { get; set; }
}
