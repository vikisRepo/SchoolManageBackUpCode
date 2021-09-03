import { Address } from "../../shared/address/address";

export class Student {
    aadharNumber? : string;
    academicPrecentage? : string;
    addresses ?: Address[] ;
    admissionNumber ?: string;
    amissionDate?: string;
    bloodGroup?: string;
    class?: string;
    dob?: string;
    emailId?: string;
    emisNumber?: string;
    firstLanguage?: string;
    firstName?: string;
    gender?: string;
    lastName?: string;
    middleName?: string;
    mobile?: string;
    salutation?: string;
    nationalityId?: string;
    passingOutSchool?: string;
    reasonForLeaving?: string;
    religionId?: string;
    rollNo?: string;
    schoolBrand?: string;
    schoolName?: string;
    secondLanguage?: string;
    section?: string;
    yearofattendence?: string;
    fatherDetails?: Dependents;
    motherDetails?: Dependents;
    localGuardian?: Dependents;
    legalGuardian?: Dependents;
}

export class Dependents {
    aadharNumber?: string;
    annualIncome?: string;
    bvEmployee?: boolean;
    company?: string;
    designation?: string;
    email?: string;
    firstName?: string;
    lastName?: string;
    middleName?: string;
    mobileNumber?: string;
    occupation?: string;
    salutation?: string;
}
