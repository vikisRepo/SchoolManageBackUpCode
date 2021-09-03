import { StaffExperience } from "./staff-experience";
import { Address } from "../../shared/address/address";

export class Staff {
      salutation?: string;
      dob?: Date ;
      religionId?: string ;
      motherTonge?: string ;
      firstName?: string ;
      bloodGroup?: string ;
      gender?: string ;
      emailId?: string ;
      languages?: string ;
      middleName?: string ;
      maritalStatus?: string ;
      nationality?: string ;
      personalEmail?: string ;
      lastName?: string ;
      weedingDate?: string ;
      mobile?: string ;
      aadharNumber?: string ;
      fatherName?: string ;
      motherName?: string ;
      spouseName?: string ;
      fatherOccupation?: string ;
      motherOccupation?: string ;
      souseOccupation?: string ;
      fatherMobileNumber?: string ;
      motherMobileNumber?: string ;
      spouseMobileNumber?: string ;
      teacherId ?: string ;
      employeeId ?: string ;
      educationId ?: string ;
      officialEmailId ?: string ;
      esiNumber ?: string ;
      staffId ?: string ;
      employeementstatusId ?: string ;
      reportingTo ?: string ;
      epfNumber ?: string ;
      departmentId ?: string ;
      joiningDate ?: string ;
      activeId ?: string ;
      uanNumber ?: string ;
      designationId ?: string ;
      roleId ?: string ;
      bankName ?: string ;
      bankAccountNumber ?: string ;
      panNumber ?: string ;
      branchNumber ?: string ;
      bankIfscCode ?: string ;
      staffExperience ?: StaffExperience[] ;
      addresses ?: Address[] ;
}
