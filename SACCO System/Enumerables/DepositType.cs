namespace SACCO_System.Enumerables
{

    /*DEFINITIONS
     * Share Capital Deposits: 
     * Members often contribute share capital as part of their membership in the SACCO. 
     * Share capital represents the member's ownership stake in the cooperative. 
     * These deposits may not be withdrawable during the membership tenure and may earn dividends instead of regular interest.
     * 
     * Savings Deposits: 
     * These are the primary type of deposits in a SACCO. 
     * Members deposit their savings into their accounts, which can earn interest over time. 
     * Savings deposits may have different sub-categories, such as regular savings, recurring deposits, or target savings.
     * 
     * Fixed Deposits/Term Deposits: 
     * These are deposits made for a specific period (term) with a predetermined interest rate. 
     * The money is locked for the agreed duration, and members earn higher interest compared to regular savings accounts.
     * 
     * Special Deposits: 
     * SACCOs may offer special deposit accounts for specific purposes, such as education savings, housing savings, or retirement savings. 
     * These accounts may have unique terms, features, and conditions tailored to the intended purpose.
     */
    public enum DepositType
    {
        SAVINGS,
        FIXED,
        SHARE_CAPITAL,
        SPECIAL_DEPOSITS
    }
}
