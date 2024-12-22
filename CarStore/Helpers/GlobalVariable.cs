using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supabase;

namespace CarStore.Helpers;
public static class GlobalVariable
{
    private static string supabaseUrl = "https://qlhadsqzinowxtappxes.supabase.co";
    private static string supabaseKey = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9." +
                                            "eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6InFsaGFkc3F6aW5vd3h0YXBweGVzIiwicm9sZSI6InNlcnZ" +
                                            "pY2Vfcm9sZSIsImlhdCI6MTczMzQ3MzUzMSwiZXhwIjoyMDQ5MDQ5NTMxfQ." +
                                            "q9LuucC7SvS2CqL9osIr-4EfS66tum-tPA8IA2BUric";
    public static string bucket = "CarStore";

    public static Client Supabase
    {
        get; set;
    } = new Client(supabaseUrl, supabaseKey);
}
