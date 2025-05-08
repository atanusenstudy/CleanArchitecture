using Autofac;
using Core.Aggregate.Validations;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core;

public class DefaultCoreModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        /*
        builder.RegisterType<BaseExampleValidator>().As<IMockEquipmentService>().InstancePerLifetimeScope();
        builder.RegisterType<MockServiceAgreementService>().As<IMockServiceAgreement>().InstancePerLifetimeScope();
        builder.RegisterType<CreateServiceAgreementValidator>().As<IValidator<CreateServiceAgreementRequest>>().InstancePerLifetimeScope();
        builder.RegisterType<EditServiceAgreementValidator>().As<IValidator<EditServiceAgreementRequest>>().InstancePerLifetimeScope();
        builder.RegisterType<PatchServiceAgreementRequestValidator>().As<IValidator<PatchServiceAgreementRequest>>().InstancePerLifetimeScope();
        */
        }
}
