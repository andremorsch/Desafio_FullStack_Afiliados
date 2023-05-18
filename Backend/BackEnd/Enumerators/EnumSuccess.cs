using System.ComponentModel;

namespace BackEnd.Enumerators
{
    public enum EnumSuccess
    {
        [Description("Sucesso total")]
        TOTAL_SUCCESS,
        [Description("Sucesso parcial")]
        PARCIAL_SUCCESS,
        [Description("Falha Total")]
        TOTAL_FAILURE
    }
}
