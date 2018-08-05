﻿using DotNetty.Common.Internal.Logging;
using DotNetty.Transport.Channels;
using MultipleProtocols.Comon;

namespace MultipleProtocols.Server
{
    public class AHandler : SimpleChannelInboundHandler<A>
    {
        static readonly IInternalLogger Logger = InternalLoggerFactory.GetInstance<AHandler>();

        protected override void ChannelRead0(IChannelHandlerContext ctx, A obj)
        {
            ctx.WriteAsync($"You send me an A object with message: '{obj.Message}'\r\n");
        }

        public override void ChannelReadComplete(IChannelHandlerContext ctx)
        {
            ctx.Flush();
        }

        public override bool IsSharable => true;
    }
}