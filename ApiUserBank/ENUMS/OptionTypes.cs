using System.ComponentModel;

namespace ApiUserBank.ENUMS;


public enum OptionTypes
{
    [Description("Sacar")] Sacar,
    [Description("Depositar")] Depositar,
    [Description("Saldo")] Saldo
}