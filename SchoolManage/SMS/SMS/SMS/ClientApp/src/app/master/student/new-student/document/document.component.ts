import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validator } from '@angular/forms';
import { HttpClient, HttpClientModule, HttpEventType } from '@angular/common/http';
import { ConstantPool } from '@angular/compiler';
import { SSL_OP_NO_TLSv1_1 } from 'constants';
import { ShowHideDirective } from '@angular/flex-layout';
import { $ } from 'protractor';
import { ViewChild } from '@angular/core';
import { AngularFileUploaderComponent } from "angular-file-uploader";
import { BlockUI, NgBlockUI } from 'ng-block-ui';
import { FormTouched } from 'src/app/shared/interfaces/form-touched';
import { UploadDownloadService } from 'src/app/shared/upload-download.service';
import { StudentrestApiService } from '../../studentrest-api.service';


@Component({
  selector: 'app-document',
  templateUrl: './document.component.html',
  styleUrls: ['./document.component.css']
})
export class DocumentComponent implements OnInit ,FormTouched{
  @Output() stuFormDetails = new EventEmitter();
  @Input() public studentDocumentDetails  : any;
  studentdocrequest : any = {};
  documentForm: FormGroup;
  selectedFile: any = null;
  result: any = null;
  t1img: boolean = false;
  bSuccessImages: boolean = false;
  t1fileName: any = null;
  bCertificareName: any = null;
  passportName: any = null;
  aadharName: any = null;
  RationCardName: any = null;
  all_files: File[] = Array();
  resetVar: any = true;
  imgPath: any = null;
  @BlockUI() blockUI: NgBlockUI;

  attachementTitles=[
  "Transfer Certificate","Birth Certificate","Passport","Aadhaar","Ration Card","Student Visa"
  ]

  @ViewChild('fileUpload1')
  private fileUpload1: AngularFileUploaderComponent;

  public response: { dbPath: '' };
  fileName : any;


  afuConfig = {
    multiple: false,
    formatsAllowed: ".jpg,.png",
    maxSize: "1",
    uploadAPI: {
      url: "api/api/upload",
      method: "POST",
      //   headers: {
      //  "Content-Type" : "text/plain;charset=UTF-8",
      //   },
      params: {
        'page': '1'
      },
      responseType: 'blob',
    },
    theme: "attachPin",
    hideProgressBar: true,
    hideResetBtn: true,
    hideSelectBtn: true,
    fileNameIndex: true,
    replaceTexts: {
      selectFileBtn: 'Select Files',
      resetBtn: 'Reset',
      uploadBtn: 'Upload',
      dragNDropBox: 'Drag N Drop',
      attachPinBtn: 'Attach Files...',
      afterUploadMsg_success: 'Successfully Uploaded !',
      afterUploadMsg_error: 'Upload Failed !',
      sizeLimit: 'Size Limit'
    }
  };

  constructor(private http: HttpClient, private fb: FormBuilder, 
    private service: UploadDownloadService,
    private studentApiService: StudentrestApiService) {
    this.documentForm = this.fb.group({
      transferCertificate: ['']
      , birthCertificate: ['']
      , passport: ['']
      , aadhar: ['']
      , rationCard: ['']
      , studentVisa: ['']
    });
    this.documentForm.valueChanges.subscribe(() => {
      console.log("Documentjson" + JSON.stringify(this.studentDocumentDetails));
      this.stuFormDetails.emit({ value: this.documentForm, valid: this.documentForm.valid });
    })
  }

  formTouched(): boolean {
    this.documentForm.markAllAsTouched();
    return this.documentForm.valid;
  }

  onSubmit() {
    console.warn(this.documentForm.value);
  }

  Onfilesave(event: any, count: any) {

    for (let i = 0; i < this.all_files.length; i++) {
      // console.log('File:', this.all_files[i], 'Name:', this.all_files[i].name);
    }

  }

  public uploadFinished = (event) => {
    this.response = event;
    this.imgPath = this.response.dbPath;
  }

  ngOnInit(): void {
  }
  // backTab(index:number)
  // {

  // }
  OnUpload() {
    this.blockUI.start();
    const fd = new FormData();
    fd.append('image', this.selectedFile, this.selectedFile.name);
    this.http.post('', fd).subscribe(res => {
      console.log(res);
    });
    this.blockUI.stop();
  }

  public upload(event, doc: any) {
    if (event.target.files && event.target.files.length > 0) {
      const file = event.target.files[0];
      this.studentdocrequest = {admissionNumber : this.studentDocumentDetails.admissionNumber, documentType : doc};
      // this.uploadStatus.emit({status: ProgressStatusEnum.START});
      this.service.uploadFile(file, this.studentdocrequest).subscribe(
        data => {
          if (data) {
            switch (data.type) {
              case HttpEventType.UploadProgress:
                // this.uploadStatus.emit( {status: ProgressStatusEnum.IN_PROGRESS, percentage: Math.round((data.loaded / data.total) * 100)});
                break;
              case HttpEventType.Response:
                // this.inputFile.nativeElement.value = '';
                // this.uploadStatus.emit( {status: ProgressStatusEnum.COMPLETE});
                break;
            }
          }
        },
        error => {
          // this.inputFile.nativeElement.value = '';
          // this.uploadStatus.emit({status: ProgressStatusEnum.ERROR});
        }
      );
    }
  }

  public download(event, doc : any) {
    // this.downloadStatus.emit( {status: ProgressStatusEnum.START});
    // setTimeout(() => {
    // this.studentApiService.GetStudentDocumentDetails(this.studentDocumentDetails.admissionNumber,doc).subscribe( (data) =>{
    //   console.log(JSON.stringify(data));
    //   this.fileName = data;
    // });
    // }, 250);
    this.service.GetStudentDocumentDetails(this.studentDocumentDetails.admissionNumber, doc).toPromise().then(
      filedata => {
        this.fileName = filedata.pathToFile;
        this.service.downloadFile(this.fileName).subscribe(
          data => {
            switch (data.type) {
              case HttpEventType.DownloadProgress:
                // this.downloadStatus.emit( {status: ProgressStatusEnum.IN_PROGRESS, percentage: Math.round((data.loaded / data.total) * 100)});
                break;
              case HttpEventType.Response:
                // this.downloadStatus.emit( {status: ProgressStatusEnum.COMPLETE});
                const downloadedFile = new Blob([data.body], { type: data.body.type });
                const a = document.createElement('a');
                a.setAttribute('style', 'display:none;');
                document.body.appendChild(a);
                a.download = this.fileName;
                a.href = URL.createObjectURL(downloadedFile);
                a.target = '_blank';
                a.click();
                document.body.removeChild(a);
                break;
            }
          },
          error => {
            // this.downloadStatus.emit( {status: ProgressStatusEnum.ERROR});
          }
        );
      }
    )
    debugger;  

    
  }



}
