using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL {
    internal static class sql
    {
        internal static string companyInsert = @"insert into `company` 
                                            (sg_company_name,
                                            liscence,
                                            legal_representative,
                                            Approval_of_the_year,
                                            service_area,
                                            is_across_zone,                                            
                                            Registered_Address,
                                            business_address,
                                            registered_capital,
                                            branch_office,
                                            management_layer,
                                            phone,
                                            allstaff_num,
                                            administrator_num,
                                            Security_Officer_num,
                                            Security_Officer_name,
                                            r_and_p  )
                                            VALUES 
                                            ('{0}',
                                            '{1}',
                                            '{2}',
                                            '{3}',
                                            '{4}',
                                            '{5}',
                                            '{6}',
                                            '{7}',
                                            '{8}',
                                            '{9}',
                                            '{10}',
                                            '{11}',
                                            '{12}',
                                            '{13}',
                                            '{14}',
                                            '{15}',
                                            '{16}')";

        internal static string companyQueryList = @"SELECT * FROM company a";
        internal static string GuardInsert=@"insert into`staff`(name,
                                            phone,
                                            certificate_num,
                                            service_area,
                                            ID_card,
                                            army,
                                            r_and_p,
                                            address,
                                            Hukou,
                                            contact_way,
                                            political_status,
                                            part_of_company,
                                            serviceunit,
                                            h_and_w,
                                            sex,
                                            soldier, 	
                                            approve_time ,
                                            date_of_birth,
                                            major_skill,
                                            training_record)
                                            values
                                            ('{0}',
                                            '{1}', 
                                            '{2}', 
                                            '{3}', 
                                            '{4}', 
                                            '{5}',
                                            '{6}',
                                            '{7}',
                                            '{8}',
                                            '{9}',
                                            '{10}',
                                            '{11}',
                                            '{12}',
                                            '{13}',
                                            '{14}',
                                            '{15}',
                                            '{16}',
                                            '{17}',
                                            '{18}',
                                            '{19}')";
        internal static string GuardQueryList= @"Select
                name, phone, certificate_num, service_area, ID_card, army, r_and_p,
                address, Hukou, contact_way, political_status, part_of_company, serviceunit, h_and_w, sex, soldier, 
                DATE_FORMAT(approve_time,'%y-%m-%d %H:%i:%s') approve_time,
                DATE_FORMAT(date_of_birth,'%y-%m-%d %H:%i:%s') date_of_birth,
                major_skill, training_record
                from staff ";
    }
}
