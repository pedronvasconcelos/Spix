using Spix.Application.Core;

namespace Spix.Application.Spixers.GetDetails;

public class GetSpixerDetailQuery : IQuery<GetSpixerDetailResponse>
{
    public Guid Id { get; set; }    
}


public class GetSpixerDetailQueryHandler : IQueryHandler<GetSpixerDetailQuery, GetSpixerDetailResponse>
{
    public Task<GetSpixerDetailResponse> Handle(GetSpixerDetailQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}       
