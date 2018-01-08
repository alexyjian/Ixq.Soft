using System;
using Ixq.Core.Dto;
using Ixq.Core.Entity;
using Ixq.Core.Mapper;
using Newtonsoft.Json;

namespace Ixq.Soft.Core.Dtos.Base
{
    public class DtoBaseLong<TEntity> : IDto<TEntity, long>
        where TEntity : class, IEntity<long>
    {
        public DtoBaseLong():this(MapperProvider.Current) { }
        public DtoBaseLong(IMapper mapper)
        {
            Mapper = mapper;
        }

        public long Id { get; set; }

        [JsonIgnore]
        public IMapper Mapper { get; set; }

        public TEntity MapTo()
        {
            if (Mapper == null)
                throw new ArgumentNullException(nameof(Mapper), "尚未初始化Mapper组件。");
            return Mapper.MapTo<TEntity>(this);
        }
    }
}
