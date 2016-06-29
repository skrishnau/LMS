--USE [hms_heritage_full]
--GO
--/****** Object:  StoredProcedure [dbo].[SP_VAT_REPORT]    Script Date: 02/05/2016 15:43:41 ******/
--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO

--ALTER proc [dbo].[SP_VAT_REPORT]  --'2015-07-17','2015-07-18','Tariff and Plan','','TRNS_DATE'
--	@FROM_DATE DATE
--	, @TO_DATE DATE 
--	, @TYPE VARCHAR(20)
--	,@outletName nvarchar(100)=''
--    ,@DATE_FILTER_TYPE nvarchar(100)
--    ,@WithTotal bit = 1
--	AS 
	BEGIN
	
	DECLARE @FROM_DATE DATE ='2015/1/1'
	DECLARE @TO_DATE DATE ='2016/2/5'
	declare  @WithTotal bit = 1

	DECLARE @TYPE VARCHAR(20)='MINIBAR'
	--DECLARE @TYPE VARCHAR(20)='POS'
	--DECLARE @TYPE VARCHAR(20)='LAUNDRY'
	--DECLARE @TYPE VARCHAR(20)='Tariff and Plan'
	--DECLARE @TYPE VARCHAR(20)='Others'

    DECLARE @outletName nvarchar(100)='the cafe garden'

		 --DECLARE @DATE_FILTER_TYPE nvarchar(100)='ACC_DATE'
   DECLARE @DATE_FILTER_TYPE nvarchar(100)='TRNS_DATE'

	DECLARE @RESULT TABLE(
                                FISCAL_yEAR VARCHAR(100)
                                ,DATE VARCHAR(50)
                                ,ACC_DATE VARCHAR(50)
								, INVOICENO VARCHAR(50) DEFAULT ''
								, BUYERNAME NVARCHAR(100) DEFAULT ''
								,TPIN VARCHAR(20) DEFAULT ''
								, TOTALAMT VARCHAR(20) DEFAULT ''
								, SALES VARCHAR(20) DEFAULT ''
								, SC VARCHAR(20) DEFAULT ''
								, VATABLE VARCHAR(20) DEFAULT ''
								,VAT VARCHAR(20) DEFAULT ''
								,DISCOUNT NVARCHAR(20) DEFAULT ''
                                 ,refId BIGINT DEFAULT 0

                                ,Is_printed NVARCHAR(10)
                                ,Is_Active NVARCHAR(10)
                                ,Printed_Time VARCHAR(50)
                                ,Entered_by NVARCHAR(100)
                                ,Printed_by NVARCHAR(100)

								,bold bit default 0 
								,TransactionRefId BIGINT DEFAULT 0
								)
	DECLARE @RESULT_TEMP TABLE(DATE VARCHAR(50)
                                ,ACC_DATE VARCHAR(50)
								, INVOICENO VARCHAR(50) DEFAULT ''
								, BUYERNAME NVARCHAR(100) DEFAULT ''
								,TPIN VARCHAR(20) DEFAULT ''
								, TOTALAMT NUMERIC(18,4) DEFAULT 0
								, SALES NUMERIC(18,4)
								, SC NUMERIC(18,4)
								, VATABLE NUMERIC(18,4) DEFAULT 0
								,VAT NUMERIC(18,4)
								,DISCOUNT  NUMERIC(18,4) DEFAULT 0
								,EXCH_RATE NUMERIC(18,4) DEFAULT 1
								,bold bit default 0
								,filter NUMERIC(18,4) DEFAULT 0
                                ,refId BIGINT DEFAULT 0
                                

                               --  ,Is_printed NVARCHAR(10)
                                ,Is_Active NVARCHAR(10)
                                --,Printed_Time VARCHAR(50)
                                ,Entered_by NVARCHAR(100)
                                --,Printed_by NVARCHAR(100)
                                ,TransactionRefId BIGINT DEFAULT 0
								 )
	DECLARE @RESULT_TEMP_ORDER TABLE(DATE VARCHAR(50)
                                ,ACC_DATE VARCHAR(50)
								, INVOICENO VARCHAR(50) DEFAULT ''
								, BUYERNAME NVARCHAR(100) DEFAULT ''
								,TPIN VARCHAR(20) DEFAULT ''
								, TOTALAMT NUMERIC(18,4) DEFAULT 0
								, SALES NUMERIC(18,4)
								, SC NUMERIC(18,4)
								, VATABLE NUMERIC(18,4) DEFAULT 0
								,VAT NUMERIC(18,4)
								,DISCOUNT  NUMERIC(18,4) DEFAULT 0
								,EXCH_RATE NUMERIC(18,4) DEFAULT 1
								,bold bit default 0
								,filter NUMERIC(18,4) DEFAULT 0
                                ,refId BIGINT DEFAULT 0
                                 

                               --  ,Is_printed NVARCHAR(10)
                                ,Is_Active NVARCHAR(10)
                                --,Printed_Time VARCHAR(50)
                                ,Entered_by NVARCHAR(100)
                                --,Printed_by NVARCHAR(100)
                                ,TransactionRefId BIGINT DEFAULT 0
								 )
	DECLARE @RESULT_TEMP_noVoid TABLE(DATE VARCHAR(50)
                                ,ACC_DATE VARCHAR(50)
								, INVOICENO VARCHAR(50) DEFAULT ''
								, BUYERNAME NVARCHAR(100) DEFAULT ''
								,TPIN VARCHAR(20) DEFAULT ''
								, TOTALAMT NUMERIC(18,4) DEFAULT 0
								, SALES NUMERIC(18,4)
								, SC NUMERIC(18,4)
								, VATABLE NUMERIC(18,4) DEFAULT 0
								,VAT NUMERIC(18,4)
								,DISCOUNT  NUMERIC(18,4) DEFAULT 0
								,EXCH_RATE NUMERIC(18,4) DEFAULT 1
								,bold bit default 0
								,filter NUMERIC(18,4) DEFAULT 0
                                ,refId BIGINT DEFAULT 0

                               --  ,Is_printed NVARCHAR(10)
                                ,Is_Active NVARCHAR(10)
                                --,Printed_Time VARCHAR(50)
                                ,Entered_by NVARCHAR(100)
                                --,Printed_by NVARCHAR(100)
                                ,TransactionRefId BIGINT DEFAULT 0
								 )
	DECLARE @TEMP_TABLE TABLE(
        DATE VARCHAR(20) DEFAULT ''
        ,RECEIPT VARCHAR(50)DEFAULT ''
        , SALES NUMERIC(18,4)DEFAULT 0
        ,SC NUMERIC(18,4)DEFAULT 0
        ,VAT NUMERIC(18,4)DEFAULT 0 
        , DSC NUMERIC(18,4) DEFAULT 0
      
    )

	DECLARE @DATE VARCHAR(50)					 
								 
	IF(@TYPE ='LAUNDRY')					
	BEGIN --LAUNDRY

		INSERT INTO @RESULT_TEMP (DATE,ACC_DATE,INVOICENO,BUYERNAME,SALES,SC,VAT,TPIN,EXCH_RATE,filter,Is_Active,Entered_by,refId,TransactionRefId)
		SELECT 
			CONVERT(DATE,  LAUN.laun_TransactionDate ) DATE
			,CONVERT(DATE,  ACC_TRANS.TransactionDate ) ACC_DATE
			, LAUN.LAUN_BILL_NO 
			,GST.GUEST_TITLE +' ' + GUEST_NAME  + ISNULL(GST.GUEST_MID_NAME,'') + ISNULL( GST.GUEST_MID_NAME,'') GUESTNAME
			,case when isnull(LAUN.laun_void,0) = 0 THEN 
            LAUN.laun_total_amount -
			CONVERT(numeric(18,2),  round(case when  isnull(LAUN.laun_discount_isPer,0)=1 then isnull(LAUN.laun_discount,0)/100*LAUN.laun_total_amount else isnull( LAUN.laun_discount,0) end,2)) 
            ELSE 0 END 
			,ISNULL( (SELECT 
				(CASE WHEN ISNULL(TX.TAXTN_PERCTG ,0)=0  THEN TX.TAXTN_CHRGAMT ELSE TX.TAXTN_CHRGAMT/100 * POST.POST_CHRG_AMT END )
				FROM FO_POSTING_TAXATION TX
				INNER JOIN G_TAX_SLAB TXITEM ON TX.TAXTN_SERV_ID = TXITEM.TAX_SLAB_ID
				WHERE TXITEM.TAX_SLAB_CODE ='SC' AND TX.TAXTN_POSTIN_ID = POST.POSTING_ID),0) SC
			,ISNULL((SELECT 
				(CASE WHEN ISNULL(TX.TAXTN_PERCTG ,0)=0  THEN TX.TAXTN_CHRGAMT ELSE TX.TAXTN_CHRGAMT/100 * POST.POST_CHRG_AMT END )
				FROM FO_POSTING_TAXATION TX
				INNER JOIN G_TAX_SLAB TXITEM ON TX.TAXTN_SERV_ID = TXITEM.TAX_SLAB_ID
				WHERE TXITEM.TAX_SLAB_CODE ='VAT' AND TX.TAXTN_POSTIN_ID = POST.POSTING_ID),0 )VAT
			,ISNULL( COMP.COMPANY_PAN,'')
			,ISNULL( POST.POST_CURR_EXHC_RATE,1)
			,CAST(SUBSTRING( LAUN.LAUN_BILL_NO,(select len(doc_prefix)from g_docnumbering where doc_type = 'Laundry_Bill')+1,len( LAUN.LAUN_BILL_NO)) AS integer)
            ,CASE WHEN ISNULL(LAUN.laun_void,0)=0 THEN 'YES' ELSE 'NO' END
            ,USR.UserName
            ,LAUN.laun_serviceTransID
            ,ACC_TRANS.TransactionId
		FROM FO_G_LAUN_SERVICETRANSACTIONMASTER LAUN
			left JOIN  FO_POSTING POST  ON LAUN.LAUN_SERVICETRANSID = POST.POST_REF_ID and POST_TYPE = 'REVENUE' AND POST_SUB_TYPE = 'LAUNDRY' 
            left  JOIN FO_POSTING POST_SETT ON POST.post_bill_no = POST_SETT.POST_BILL_NO AND (POST_SETT.POST_TYPE = 'AMOUNTCOLLECTION'  and  POST_SETT.POST_SUB_TYPE='CHECKOUTPAYMENT')
		    left  JOIN dbo.[Transaction] ACC_TRANS ON  ACC_TRANS.RefId = POST_SETT.posting_id AND (ACC_TRANS.RefSource = 'CHKOTPMT_SETT' OR ACC_TRANS.RefSource = 'BILLTOCMP_SETT')
			left JOIN FO_RESV_GUEST_RESERVATION_DETAIL GST_RESV ON LAUN.LAU_RESV_GUEST_ID = GST_RESV.RESV_GUEST_ID
			left JOIN FO_G_GUEST GST ON GST_RESV.GUEST_ID=GST.GUEST_ID
			LEFT JOIN FO_FOLIO_MASTER FOLIO ON (FOLIO.FOLIO_TYPE='COMPANYFOLIO' AND FOLIO.FOLIO_ID = POST.POST_FOLIO_ID)
			LEFT JOIN AR_G_COMPANY COMP ON FOLIO.FOLIO_CMP_ID = COMP.COMPANY_ID
            LEFT JOIN dbo.Prl_Employee EMP ON EMP.Id = LAUN.create_user
            LEFT JOIN dbo.aspnet_Users USR ON EMP.user_id = USR.UserId
		WHERE 
        (
        ( @DATE_FILTER_TYPE = 'TRNS_DATE' AND  CONVERT(DATE,LAUN.laun_TransactionDate ) BETWEEN @FROM_DATE AND @TO_DATE)
        OR ( @DATE_FILTER_TYPE = 'ACC_DATE' AND CONVERT(DATE,ACC_TRANS.TransactionDate) BETWEEN @FROM_DATE AND @TO_DATE)
        )
	END
	
	--MINIBAR START
	ELSE IF (@TYPE='MINIBAR')
	BEGIN
		declare @MiniBarPostingTable table(DATE VARCHAR(50)
                                ,ACC_DATE VARCHAR(50)
								, INVOICENO VARCHAR(50) DEFAULT ''
								, BUYERNAME NVARCHAR(100) DEFAULT ''
								,TPIN VARCHAR(20) DEFAULT ''
								, TOTALAMT NUMERIC(18,4) DEFAULT 0
								, SALES NUMERIC(18,4)
								, SC NUMERIC(18,4)
								, VATABLE NUMERIC(18,4) DEFAULT 0
								,VAT NUMERIC(18,4)
								,DISCOUNT  NUMERIC(18,4) DEFAULT 0
								,EXCH_RATE NUMERIC(18,4) DEFAULT 1
								,bold bit default 0
								,filter NUMERIC(18,4) DEFAULT 0
                                ,refId BIGINT DEFAULT 0

                               --  ,Is_printed NVARCHAR(10)
                                ,Is_Active NVARCHAR(10)
                                --,Printed_Time VARCHAR(50)
                                ,Entered_by NVARCHAR(100)
                                --,Printed_by NVARCHAR(100)
                                ,TransactionRefId BIGINT DEFAULT 0
								 )
		
		INSERT INTO @MiniBarPostingTable (DATE,ACC_DATE,INVOICENO,BUYERNAME,SALES,SC,VAT,TPIN,EXCH_RATE,filter,Is_Active,Entered_by,refId,TransactionRefId)
		SELECT  
			CONVERT(DATE,   bill.mb_bill_date) DATE  
			,CONVERT(DATE,  ACC_TRANS.TransactionDate ) ACC_DATE
			,bill.mb_bill_billno 
			,GST.GUEST_TITLE +' ' + GUEST_NAME  + ISNULL(GST.GUEST_MID_NAME,'') + ISNULL( GST.GUEST_MID_NAME,'') GUESTNAME
			,case when isnull(bill.mb_bill_is_void,0) =0 then 
				post.post_chrg_amt
				else 0 end	
			,ISNULL( (SELECT 
				(CASE WHEN ISNULL(TX.TAXTN_PERCTG ,0)=0  THEN TX.TAXTN_CHRGAMT ELSE TX.TAXTN_CHRGAMT/100 * POST.POST_CHRG_AMT END )
				FROM FO_POSTING_TAXATION TX
				INNER JOIN G_TAX_SLAB TXITEM ON TX.TAXTN_SERV_ID = TXITEM.TAX_SLAB_ID
				WHERE TXITEM.TAX_SLAB_CODE ='SC' AND TX.TAXTN_POSTIN_ID = POST.POSTING_ID),0) SC
			,ISNULL((SELECT 
				(CASE WHEN ISNULL(TX.TAXTN_PERCTG ,0)=0  THEN TX.TAXTN_CHRGAMT ELSE TX.TAXTN_CHRGAMT/100 * POST.POST_CHRG_AMT END )
				FROM FO_POSTING_TAXATION TX
				INNER JOIN G_TAX_SLAB TXITEM ON TX.TAXTN_SERV_ID = TXITEM.TAX_SLAB_ID
				WHERE TXITEM.TAX_SLAB_CODE ='VAT' AND TX.TAXTN_POSTIN_ID = POST.POSTING_ID),0 )VAT
			,ISNULL( COMP.COMPANY_PAN,'') Comp
			,ISNULL( POST.POST_CURR_EXHC_RATE,1) exch
			,CAST(SUBSTRING( bill.mb_bill_billno,(select len(doc_prefix)from g_docnumbering where doc_type = 'Minibar_Bill')+1,len( bill.mb_bill_billno)) AS integer)
            ,CASE WHEN ISNULL(bill.mb_bill_is_void,0)=0 THEN 'YES' ELSE 'NO' END
            ,USR.UserName
            , bill.mb_bill_id 
            ,ACC_TRANS.TransactionId
			
			FROM  FO_POSTING POST -- fo_hk_mb_bill  bill
				LEFT JOIN FO_HK_MB_BILL BILL ON POST.
			--left JOIN  FO_POSTING POST  ON POST_TYPE = 'REVENUE' AND POST_SUB_TYPE = 'MINIBAR' --con.hk_Inv_con_id = POST.POST_REF_ID and 
            left  JOIN FO_POSTING POST_SETT ON POST.post_bill_no = POST_SETT.POST_BILL_NO AND (POST_SETT.POST_TYPE = 'AMOUNTCOLLECTION'  and  POST_SETT.POST_SUB_TYPE='CHECKOUTPAYMENT')
		   left  JOIN dbo.[Transaction] ACC_TRANS ON  ACC_TRANS.RefId = POST_SETT.posting_id AND (ACC_TRANS.RefSource = 'CHKOTPMT_SETT' OR ACC_TRANS.RefSource = 'BILLTOCMP_SETT')
			LEFT JOIN FO_FOLIO_MASTER FOLIO ON (FOLIO.FOLIO_TYPE='GuestFolio' AND FOLIO.FOLIO_ID = POST.POST_FOLIO_ID)
			left JOIN FO_RESV_GUEST_RESERVATION_DETAIL GST_RESV ON Folio.folio_gst_id = GST_RESV.RESV_GUEST_ID
			left JOIN FO_G_GUEST GST ON GST_RESV.GUEST_ID=GST.GUEST_ID
			LEFT JOIN AR_G_COMPANY COMP ON FOLIO.FOLIO_CMP_ID = COMP.COMPANY_ID
			LEFT JOIN dbo.Prl_Employee EMP ON EMP.Id = bill.mb_bill_userid
            LEFT JOIN dbo.aspnet_Users USR ON EMP.user_id = USR.UserId
            WHERE 
        ( POST.POST_TYPE = 'REVENUE' AND POST.POST_SUB_TYPE = 'MINIBAR'
        ( @DATE_FILTER_TYPE = 'TRNS_DATE' AND  CONVERT(DATE,bill.mb_bill_date) BETWEEN @FROM_DATE AND @TO_DATE)
        OR ( @DATE_FILTER_TYPE = 'ACC_DATE' AND CONVERT(DATE,ACC_TRANS.TransactionDate) BETWEEN @FROM_DATE AND @TO_DATE)
        )
  --      INSERT INTO @RESULT_TEMP (DATE,ACC_DATE,INVOICENO,BUYERNAME,SALES,SC,VAT,TPIN,EXCH_RATE,filter,Is_Active,Entered_by,refId,TransactionRefId)
		--SELECT  
        
       --select * from @RESULT_TEMP
       
       
	END
	--MINIBAR END
	
	ELSE IF(@TYPE='POS')
	BEGIN -- RESTAURANT
	  INSERT INTO @RESULT_TEMP( DATE ,ACC_DATE ,INVOICENO ,SALES ,SC ,VAT ,DISCOUNT,filter ,Is_Active,Entered_by,refId,TransactionRefId)
		SELECT 
        --DISTINCT
		--outlet.Outlet_name
             CONVERT(DATE, rcpt.DateNTime) DATE
            ,CONVERT(DATE, ACC_TRANS.TransactionDate)
            --,CONVERT(DATE, ISNULL(ACC_TRANS.TransactionDate,ACC_TRANS_for_non_Resv.TransactionDate) )
			,rcpt.Receipt_BillNo  RECEIPT
			, isnull( POST.POST_CHRG_AMT *post.POST_CURR_EXHC_RATE,0) SALES
			 ,(SELECT ( 
			 ISNULL(	(CASE WHEN ISNULL(TX.TAXTN_PERCTG ,0)=0  THEN TX.TAXTN_CHRGAMT ELSE TX.TAXTN_CHRGAMT/100 * POST_CHRG_AMT END ),0)*POST_CURR_EXHC_RATE)
				FROM FO_POSTING_TAXATION TX
				INNER JOIN G_TAX_SLAB TXITEM ON TX.TAXTN_SERV_ID = TXITEM.TAX_SLAB_ID
				INNER JOIN FO_POSTING ON POSTING_ID = TX.TAXTN_POSTIN_ID
				WHERE TXITEM.TAX_SLAB_CODE ='SC' AND  POST_TYPE = 'REVENUE'
				AND POST_SUB_TYPE = 'RESTAURANT' AND POST_RECEIPT_NO = POST.POST_RECEIPT_NO) SC
			 ,(SELECT ( 
			 ISNULL(	(CASE WHEN ISNULL(TX.TAXTN_PERCTG ,0)=0  THEN TX.TAXTN_CHRGAMT ELSE TX.TAXTN_CHRGAMT/100 * POST_CHRG_AMT END ),0)*POST_CURR_EXHC_RATE)
				FROM FO_POSTING_TAXATION TX
				INNER JOIN G_TAX_SLAB TXITEM ON TX.TAXTN_SERV_ID = TXITEM.TAX_SLAB_ID
				INNER JOIN FO_POSTING ON POSTING_ID = TX.TAXTN_POSTIN_ID
				WHERE TXITEM.TAX_SLAB_CODE ='VAT' AND  POST_TYPE = 'REVENUE'
				AND POST_SUB_TYPE = 'RESTAURANT' AND POST_RECEIPT_NO = POST.POST_RECEIPT_NO) VAT
			,( ISNULL( (CASE 
							WHEN  ISNULL(POST.POST_DSCNT_PER,0) = 0 
							THEN POST.POST_DSCNT_AMT 
							ELSE 
							--POST_DSCNT_AMT/100 * POST_CHRG_AMT 
							POST.post_dscnt_amt/100*((100*POST.post_chrg_amt)/(100-POST.post_dscnt_amt))
							
							END ),0)*POST.POST_CURR_EXHC_RATE)DSC
			,CAST(SUBSTRING( rcpt.Receipt_BillNo,2,len(rcpt.Receipt_BillNo)) AS integer) 
            ,CASE WHEN  (ISNULL(rcpt.VOID,0)=0 AND rcpt.ISPRINTED=1 )THEN 'YES' ELSE 'NO' END
            
            ,Usr.UserName
            ,rcpt.Receipt_Id
            ,ACC_TRANS.TransactionId
  -- rcpt.Receipt_BillNo,outlet.Outlet_id,set
		FROM  pos_Receipt rcpt
		inner join pos_Outlet_setups outlet on rcpt.Receipt_Outlet_id = outlet.Outlet_id and @outletName = outlet.Outlet_name
        LEFT JOIN dbo.pos_Settlement sett ON sett.ReceiptId = rcpt.Receipt_SN
        LEFT JOIN  FO_POSTING POST on (post.post_receipt_no = rcpt.Receipt_BillNo  AND POST_TYPE = 'REVENUE' AND POST_SUB_TYPE = 'RESTAURANT' )
        left  JOIN FO_POSTING POST_SETT ON POST.post_bill_no = POST_SETT.POST_BILL_NO AND (POST_SETT.POST_TYPE = 'AMOUNTCOLLECTION'  and  POST_SETT.POST_SUB_TYPE='CHECKOUTPAYMENT')
		left  JOIN dbo.[Transaction] ACC_TRANS ON
                    ( 
                       (  ACC_TRANS.RefId = POST_SETT.posting_id AND (ACC_TRANS.RefSource = 'CHKOTPMT_SETT' OR ACC_TRANS.RefSource = 'BILLTOCMP_SETT'))
                        OR 
                        (ACC_TRANS.RefId = sett.SettlementId AND ACC_TRANS.RefSource IN( 'REST_SETT','REST_REV'))
                    )
        LEFT JOIN dbo.pos_Employee_info EMP ON sett.SettlementBy = EMP.Emp_userName
        LEFT JOIN dbo.aspnet_Users Usr ON Usr.UserId = EMP.Emp_UserId
        
		WHERE 
         (
        ( @DATE_FILTER_TYPE = 'TRNS_DATE' AND  CONVERT(DATE, rcpt.DateNTime)BETWEEN @FROM_DATE AND @TO_DATE)
        OR ( @DATE_FILTER_TYPE = 'ACC_DATE' AND CONVERT(DATE,ACC_TRANS.TransactionDate) BETWEEN @FROM_DATE AND @TO_DATE)
        )
        and isnull(sett.Void,0)=0
        AND SUBSTRING(rcpt.Receipt_BillNo,1,1) <> 'C'
	END
	ELSE IF(@TYPE = 'Tariff and Plan')
	BEGIN
		IF( @DATE_FILTER_TYPE = 'ACC_DATE')
		BEGIN
		
			INSERT INTO @TEMP_TABLE(RECEIPT, SALES,SC,VAT,Dsc)
			SELECT 
				bill_details_bill_no 
				,CASE WHEN ISNULL( bill.bill_details_is_void,0)=0 THEN ISNULL( SUM( 
				CASE WHEN POST.POST_TYPE <> 'ALLOWANCE'  THEN
				POST.POST_CHRG_AMT*POST.POST_CURR_EXHC_RATE
				ELSE 0-(POST.POST_CHRG_AMT*POST.POST_CURR_EXHC_RATE)END

				),0)
				ELSE 0 END
				SALES
				,CASE WHEN ISNULL( bill.bill_details_is_void,0)=0 THEN
				ISNULL((SELECT 
				SUM (ISNULL(CASE WHEN  ISNULL(TAX.TAXTN_PERCTG  ,0)=0 
				THEN  (CASE WHEN POST_TYPE <> 'ALLOWANCE'  THEN TAX.TAXTN_CHRGAMT  ELSE  0-TAX.TAXTN_CHRGAMT  END )
				ELSE 
				(CASE WHEN POST_TYPE <> 'ALLOWANCE' 
				THEN (TAX.TAXTN_CHRGAMT/100*P.POST_CHRG_AMT)  
				ELSE  0-(TAX.TAXTN_CHRGAMT/100*P.POST_CHRG_AMT)   
				END )END,0)*P.POST_CURR_EXHC_RATE )
				FROM FO_POSTING_TAXATION  TAX
					INNER JOIN G_TAX_SLAB TS ON TAX.TAXTN_SERV_ID = TS.TAX_SLAB_ID AND TS.TAX_SLAB_CODE='SC'
					INNER JOIN FO_POSTING P ON TAX.TAXTN_POSTIN_ID = P.POSTING_ID
				WHERE  (P.POST_TYPE = 'ROOMRATES'  OR  P.POST_SUB_TYPE='ROOMRATES')
					AND P.POST_BILL_NO =  BILL.bill_details_bill_no),0)
			  ELSE 0 END SC

				,CASE WHEN ISNULL( bill.bill_details_is_void,0)=0 THEN
				ISNULL((SELECT 
				SUM (ISNULL(CASE WHEN  ISNULL(TAX.TAXTN_PERCTG  ,0)=0 
				THEN  (CASE WHEN POST_TYPE <> 'ALLOWANCE'  THEN TAX.TAXTN_CHRGAMT  ELSE  0-TAX.TAXTN_CHRGAMT  END )
				ELSE 
				(CASE WHEN POST_TYPE<> 'ALLOWANCE'   
				THEN (TAX.TAXTN_CHRGAMT/100*P.POST_CHRG_AMT)  
				ELSE  0-(TAX.TAXTN_CHRGAMT/100*P.POST_CHRG_AMT)   
				END )END,0)*P.POST_CURR_EXHC_RATE)
				FROM FO_POSTING_TAXATION  TAX
					INNER JOIN G_TAX_SLAB TS ON TAX.TAXTN_SERV_ID = TS.TAX_SLAB_ID AND TS.TAX_SLAB_CODE='VAT'
					INNER JOIN FO_POSTING P ON TAX.TAXTN_POSTIN_ID = P.POSTING_ID
				WHERE  (P.POST_TYPE = 'ROOMRATES'  OR  P.POST_SUB_TYPE='ROOMRATES') 
					AND P.POST_BILL_NO = BILL.bill_details_bill_no),0)
				 ELSE 0 END VAT

                 ,CASE WHEN ISNULL( bill.bill_details_is_void,0)<>0 THEN 0
                        ELSE
                        ISNULL( SUM(  
                        CASE WHEN ISNULL(POST.post_dscnt_per,0)=0 THEN 
                       (post.post_dscnt_amt) *POST.POST_CURR_EXHC_RATE
                        ELSE (POST.post_dscnt_amt/100 *(POST.POST_CHRG_AMT*100)/(100 - POST.post_dscnt_amt)     )*POST.POST_CURR_EXHC_RATE
                        END),0)
				END 
				DSC
            

			FROM FO_G_BILL_DETAILS_TYPE BILL
			left  JOIN FO_POSTING POST ON BILL.BILL_DETAILS_BILL_NO = POST_BILL_NO AND (POST_TYPE = 'ROOMRATES'  OR  POST_SUB_TYPE='ROOMRATES')
			left  JOIN FO_POSTING POST_SETT ON BILL.BILL_DETAILS_BILL_NO = POST_SETT.POST_BILL_NO AND (POST_SETT.POST_TYPE = 'AMOUNTCOLLECTION'  and  POST_SETT.POST_SUB_TYPE='CHECKOUTPAYMENT')
			left  JOIN dbo.[Transaction] ACC_TRANS ON  ACC_TRANS.RefId = POST_SETT.posting_id AND (ACC_TRANS.RefSource = 'CHKOTPMT_SETT' OR ACC_TRANS.RefSource = 'BILLTOCMP_SETT')
				
			WHERE BILL.bill_details_type='BillGeneration' 
			AND
			(
			( @DATE_FILTER_TYPE = 'TRNS_DATE' AND BILL.BILL_DETAILS_DATE BETWEEN @FROM_DATE AND @TO_DATE)
			OR ( @DATE_FILTER_TYPE = 'ACC_DATE' AND CONVERT(DATE,ACC_TRANS.TransactionDate) BETWEEN @FROM_DATE AND @TO_DATE)
			)
			
			GROUP BY BILL.bill_details_bill_no, BILL.bill_details_is_void 
		END
		ELSE
		BEGIN
		INSERT INTO @TEMP_TABLE(RECEIPT, SALES,SC,VAT,dsc)
			SELECT 
				bill_details_bill_no 
				,CASE WHEN ISNULL( bill.bill_details_is_void,0)=0 THEN ISNULL( SUM( 
				CASE WHEN POST.POST_TYPE <> 'ALLOWANCE'  THEN
				POST.POST_CHRG_AMT*POST.POST_CURR_EXHC_RATE
				ELSE 0-(POST.POST_CHRG_AMT*POST.POST_CURR_EXHC_RATE)END

				),0)
				ELSE 0 END
				SALES
				,CASE WHEN ISNULL( bill.bill_details_is_void,0)=0 THEN
				ISNULL((SELECT 
				SUM (ISNULL(CASE WHEN  ISNULL(TAX.TAXTN_PERCTG  ,0)=0 
				THEN  (CASE WHEN POST_TYPE <> 'ALLOWANCE'  THEN TAX.TAXTN_CHRGAMT  ELSE  0-TAX.TAXTN_CHRGAMT  END )
				ELSE 
				(CASE WHEN POST_TYPE <> 'ALLOWANCE' 
				THEN (TAX.TAXTN_CHRGAMT/100*P.POST_CHRG_AMT)  
				ELSE  0-(TAX.TAXTN_CHRGAMT/100*P.POST_CHRG_AMT)   
				END )END,0)*P.POST_CURR_EXHC_RATE )
				FROM FO_POSTING_TAXATION  TAX
					INNER JOIN G_TAX_SLAB TS ON TAX.TAXTN_SERV_ID = TS.TAX_SLAB_ID AND TS.TAX_SLAB_CODE='SC'
					INNER JOIN FO_POSTING P ON TAX.TAXTN_POSTIN_ID = P.POSTING_ID
				WHERE  (P.POST_TYPE = 'ROOMRATES'  OR  P.POST_SUB_TYPE='ROOMRATES')
					AND P.POST_BILL_NO =  BILL.bill_details_bill_no),0)
			  ELSE 0 END SC

				,CASE WHEN ISNULL( bill.bill_details_is_void,0)=0 THEN
				ISNULL((SELECT 
				SUM (ISNULL(CASE WHEN  ISNULL(TAX.TAXTN_PERCTG  ,0)=0 
				THEN  (CASE WHEN POST_TYPE <> 'ALLOWANCE'  THEN TAX.TAXTN_CHRGAMT  ELSE  0-TAX.TAXTN_CHRGAMT  END )
				ELSE 
				(CASE WHEN POST_TYPE<> 'ALLOWANCE'   
				THEN (TAX.TAXTN_CHRGAMT/100*P.POST_CHRG_AMT)  
				ELSE  0-(TAX.TAXTN_CHRGAMT/100*P.POST_CHRG_AMT)   
				END )END,0)*P.POST_CURR_EXHC_RATE)
				FROM FO_POSTING_TAXATION  TAX
					INNER JOIN G_TAX_SLAB TS ON TAX.TAXTN_SERV_ID = TS.TAX_SLAB_ID AND TS.TAX_SLAB_CODE='VAT'
					INNER JOIN FO_POSTING P ON TAX.TAXTN_POSTIN_ID = P.POSTING_ID
				WHERE  (P.POST_TYPE = 'ROOMRATES'  OR  P.POST_SUB_TYPE='ROOMRATES') 
					AND P.POST_BILL_NO = BILL.bill_details_bill_no),0)
				 ELSE 0 END VAT
                ,CASE WHEN ISNULL( bill.bill_details_is_void,0)<>0 THEN 0
                        ELSE
                        ISNULL( SUM(  
                        CASE WHEN ISNULL(POST.post_dscnt_per,0)=0 THEN 
                       (post.post_dscnt_amt) *POST.POST_CURR_EXHC_RATE
                        ELSE (POST.post_dscnt_amt/100 *(POST.POST_CHRG_AMT*100)/(100 - POST.post_dscnt_amt)     )*POST.POST_CURR_EXHC_RATE
                        END)
                ,0)
				END 
				DSC
                --,SUM(POST.post_dscnt_amt)
                --,bill_details_is_void

			FROM FO_G_BILL_DETAILS_TYPE BILL
			left  JOIN FO_POSTING POST ON BILL.BILL_DETAILS_BILL_NO = POST_BILL_NO AND (POST_TYPE = 'ROOMRATES'  OR  POST_SUB_TYPE='ROOMRATES')
			--left  JOIN FO_POSTING POST_SETT ON BILL.BILL_DETAILS_BILL_NO = POST_SETT.POST_BILL_NO AND (POST_SETT.POST_TYPE = 'AMOUNTCOLLECTION'  and  POST_SETT.POST_SUB_TYPE='CHECKOUTPAYMENT')
			--left  JOIN dbo.[Transaction] ACC_TRANS ON  ACC_TRANS.RefId = POST_SETT.posting_id AND (ACC_TRANS.RefSource = 'CHKOTPMT_SETT' OR ACC_TRANS.RefSource = 'BILLTOCMP_SETT')
				
			WHERE BILL.bill_details_type='BillGeneration' 
			AND
			(
			( @DATE_FILTER_TYPE = 'TRNS_DATE' AND BILL.BILL_DETAILS_DATE BETWEEN @FROM_DATE AND @TO_DATE)
			--OR ( @DATE_FILTER_TYPE = 'ACC_DATE' AND CONVERT(DATE,ACC_TRANS.TransactionDate) BETWEEN @FROM_DATE AND @TO_DATE)
			)
			
			GROUP BY BILL.bill_details_bill_no, BILL.bill_details_is_void 
		END
		--order by BILL.bill_details_bill_no

        INSERT INTO @RESULT_TEMP(DATE,ACC_dATE,INVOICENO,SALES,SC,VAT,BUYERNAME,TPIN,filter,Is_Active,Entered_by,refId,DISCOUNT,TransactionRefId)
		SELECT 
		CONVERT(DATE, B.BILL_DETAILS_DATE)
        , CONVERT(DATE,ACC_TRANS.TransactionDate)
		,b.bill_details_bill_no
		,T.SALES
		,T.SC
		,T.VAT
		,isnull((case when folio.folio_type ='GuestFolio' then gst.guest_title +' '+gst.guest_name +' '+ isnull(gst.guest_lst_name,'')
			  when folio.folio_type ='CompanyFolio'  then  comp.company_name
			  when folio.folio_type ='MasterFolio'  then  
			  (select top 1 G.guest_title +' '+G.guest_name +' '+ isnull(G.guest_lst_name,'') from fo_resv_guest_reservation_detail rG 
			  inner join fo_g_guest G on rG.guest_id = G.guest_id where rG.resv_id = folio.folio_resv_id
			  )
			--  when 
			  end),'')
		,COMP.company_pan 
		,CAST(SUBSTRING(b.bill_details_bill_no,(select len(doc_prefix)from g_docnumbering where doc_type = 'Accomodation_Bill')+1,len(b.bill_details_bill_no)) AS integer) 
       ,CASE WHEN ISNULL(b.bill_details_is_void,0)=0 THEN 'YES' ELSE 'NO' END
        ,USR.UserName
        ,b.bill_details_id
        ,T.DSC
        ,ACC_TRANS.TransactionId
		FROM @TEMP_TABLE T
		left JOIN FO_G_BILL_DETAILS_TYPE  B ON   T.RECEIPT = B.BILL_DETAILS_BILL_NO
		left join fo_folio_master folio on B.bill_genrted_to_folio = folio.folio_id
		left  JOIN FO_POSTING POST_SETT ON B.BILL_DETAILS_BILL_NO = POST_SETT.POST_BILL_NO AND (POST_SETT.POST_TYPE = 'AMOUNTCOLLECTION'  and  POST_SETT.POST_SUB_TYPE='CHECKOUTPAYMENT')
		left  JOIN dbo.[Transaction] ACC_TRANS ON  ACC_TRANS.RefId = POST_SETT.posting_id AND (ACC_TRANS.RefSource = 'CHKOTPMT_SETT' OR ACC_TRANS.RefSource = 'BILLTOCMP_SETT')
		left join ar_g_company comp on folio.folio_cmp_id = comp.company_id
		left join fo_g_guest gst  on folio.folio_gst_id = gst.guest_id
        LEFT JOIN dbo.Prl_Employee EMP ON EMP.Id = b.bill_details_userid
        LEFT JOIN dbo.aspnet_Users USR ON EMP.user_id = USR.UserId
		
	END
	ELSE IF(@TYPE='Others')
	BEGIN
		INSERT INTO @RESULT_TEMP (DATE,INVOICENO,BUYERNAME,SALES,SC,VAT,EXCH_RATE,filter,Is_Active,Entered_by,refId,TransactionRefId)
		SELECT 
		CONVERT(DATE,  ISNULL(POST.POST_DATE, SERV.SERVICE_DATE_FROM)) DATE
		, SERV.SERVICE_BILL_NO 
		,GST.GUEST_TITLE +' ' + GUEST_NAME  + ISNULL(GST.GUEST_MID_NAME,'') + ISNULL( GST.GUEST_MID_NAME,'') GUESTNAME
		,case when isnull(serv.isVoid,0) = 0 THEN  ISNULL(POST.POST_CHRG_AMT,0) ELSE 0 end
		--,POST.posting_id
		,ISNULL( (SELECT 
			(CASE WHEN ISNULL(TX.TAXTN_PERCTG ,0)=0  THEN TX.TAXTN_CHRGAMT ELSE TX.TAXTN_CHRGAMT/100 * POST.POST_CHRG_AMT END )
			FROM FO_POSTING_TAXATION TX
			INNER JOIN G_TAX_SLAB TXITEM ON TX.TAXTN_SERV_ID = TXITEM.TAX_SLAB_ID
			WHERE TXITEM.TAX_SLAB_CODE ='SC' AND TX.TAXTN_POSTIN_ID = POST.POSTING_ID),0) SC
		,ISNULL((SELECT 
			(CASE WHEN ISNULL(TX.TAXTN_PERCTG ,0)=0  THEN TX.TAXTN_CHRGAMT ELSE TX.TAXTN_CHRGAMT/100 * POST.POST_CHRG_AMT END )
			FROM FO_POSTING_TAXATION TX
			INNER JOIN G_TAX_SLAB TXITEM ON TX.TAXTN_SERV_ID = TXITEM.TAX_SLAB_ID
			WHERE TXITEM.TAX_SLAB_CODE ='VAT' AND TX.TAXTN_POSTIN_ID = POST.POSTING_ID),0 )VAT
		--,ISNULL( COMP.COMPANY_PAN,'')
		,ISNULL (POST.POST_CURR_EXHC_RATE,0)
		,CAST(SUBSTRING( SERV.SERVICE_BILL_NO,(SELECT LEN(DOC_PREFIX)FROM G_DOCNUMBERING WHERE DOC_TYPE = 'OTHERSERV_BILL')+1,LEN( SERV.SERVICE_BILL_NO)) AS INTEGER)
         ,CASE WHEN ISNULL(SERV.isVoid,0)=0 THEN 'YES' ELSE 'NO' END
        ,USR.UserName
        ,SERV.guest_service_id
        ,ACC_TRANS.TransactionId
		from FO_REG_GUEST_SERVICE SERV 
	    LEFT  join FO_POSTING POST ON (POST.POST_REF_ID = SERV.GUEST_SERVICE_ID AND POST_TYPE='OTHERS')
        left  JOIN FO_POSTING POST_SETT ON POST.post_bill_no = POST_SETT.POST_BILL_NO AND (POST_SETT.POST_TYPE = 'AMOUNTCOLLECTION'  and  POST_SETT.POST_SUB_TYPE='CHECKOUTPAYMENT')
		left  JOIN dbo.[Transaction] ACC_TRANS ON  ACC_TRANS.RefId = POST_SETT.posting_id AND (ACC_TRANS.RefSource = 'CHKOTPMT_SETT' OR ACC_TRANS.RefSource = 'BILLTOCMP_SETT')
        LEFT JOIN FO_G_GUEST GST ON SERV.GUEST_ID=GST.GUEST_ID
     LEFT JOIN dbo.Prl_Employee EMP ON EMP.Id = SERV.serv_created_by
        LEFT JOIN dbo.aspnet_Users USR ON EMP.user_id = USR.UserId
		WHERE    
		 (
        ( @DATE_FILTER_TYPE = 'TRNS_DATE' AND  ((  POST.POST_DATE BETWEEN @FROM_DATE AND @TO_DATE) OR SERV.SERVICE_DATE_FROM BETWEEN @FROM_DATE AND @TO_DATE ))
        OR ( @DATE_FILTER_TYPE = 'ACC_DATE' AND CONVERT(DATE,ACC_TRANS.TransactionDate) BETWEEN @FROM_DATE AND @TO_DATE)
        )
		--ORDER BY
		--CAST(SUBSTRING( SERV.SERVICE_BILL_NO,(SELECT LEN(DOC_PREFIX)FROM G_DOCNUMBERING WHERE DOC_TYPE = 'OTHERSERV_BILL')+1,LEN( SERV.SERVICE_BILL_NO)) AS INTEGER)

	END
    ELSE IF(@TYPE='BANQUET')
    BEGIN
    INSERT INTO @RESULT_TEMP (DATE,ACC_dATE,INVOICENO,BUYERNAME,SALES,SC,VAT,EXCH_RATE,filter,Is_Active,Entered_by,refId,TransactionRefId)
		    SELECT 
		    CONVERT(DATE,  BNQT_BILL.BQT_BILL_DATE) DATE
		    ,CONVERT(DATE,  ACC_TRANS.TransactionDate ) ACC_DATE
		    , BNQT_BILL.BQT_BILL_NO 
		    ,CASE WHEN ISNULL(CLIENT.bnqt_g_client_Id ,0)=0 THEN   CLIENT.bnqt_g_clnt_f_name + ' '+ISNULL(CLIENT.bnqt_g_clnt_l_name ,'')
                  ELSE COMP.company_name END BUYERNAME
		    ,case when isnull(BNQT_BILL.is_void,0) = 0 THEN  ISNULL(BNQT_BILL.bill_debit_amt,0) ELSE 0 end SALES
		    ----,POST.posting_id
	        ,case when isnull(BNQT_BILL.is_void,0) = 0 THEN  ISNULL(BNQT_BILL.bil_Sc,0) ELSE 0 END SC
	        ,case when isnull(BNQT_BILL.is_void,0) = 0 THEN  ISNULL(BNQT_BILL.bill_Vat,0) ELSE 0 END VAT
		    ,1--ISNULL (POST.POST_CURR_EXHC_RATE,0)
		    ,CAST(SUBSTRING( BNQT_BILL.bqt_bill_no,(SELECT LEN(DOC_PREFIX)FROM G_DOCNUMBERING WHERE DOC_TYPE = 'BanquetBill')+1,LEN( BNQT_BILL.bqt_bill_no)) AS INTEGER)FILTER
            ,CASE WHEN ISNULL(BNQT_BILL.is_void,0)=0 THEN 'YES' ELSE 'NO' END IS_ACTIVE
           ,USR.UserName
           ,BNQT_BILL.bqt_bill_id

            ,ACC_TRANS.TransactionId
		    from dbo.bnqt_bill_details BNQT_BILL 
            INNER JOIN dbo.bnqt_bkng_master BOOKING ON BNQT_BILL.bqt_bking_id = BOOKING.bnqt_bkng_id
            INNER JOIN dbo.pos_Outlet_setups OUTLET ON BOOKING.bnqt_bkng_outlet_Id = OUTLET.Outlet_id AND OUTLET.Outlet_name = @outletName
            LEFT JOIN dbo.bnqt_g_client CLIENT ON (BOOKING.bnqt_bkng_client_id = CLIENT.bnqt_g_client_Id AND BOOKING.bnqt_bkng_type='INDIVIDUAL')
            LEFT JOIN dbo.bnqt_g_comp BNQT_COMP ON (BOOKING.bnqt_bkng_client_id = BNQT_COMP.bnqt_cmp_id AND BOOKING.bnqt_bkng_type='COMPANY')
            LEFT JOIN dbo.ar_g_company COMP ON BNQT_COMP.ar_g_cmp_id = COMP.company_id
            LEFT JOIN dbo.bnqt_sett BNQT_SETT ON BNQT_SETT.bll_set_bill_no = BNQT_BILL.bqt_bill_no

	        --LEFT  join FO_POSTING POST ON (POST.post_bill_no = BNQT_BILL.bqt_bill_no AND POST_TYPE='AMOUNTCOLLECTION' AND post_sub_type='BANQUET' AND post_remarks='Final_Payment')-- FOR NORMAL PAYMENT

	        --LEFT  join FO_POSTING POST_FOR_REGISTRAION_SETT ON (POST_FOR_REGISTRAION_SETT.post_receipt_no = BNQT_BILL.bqt_bill_no AND POST_FOR_REGISTRAION_SETT.post_type='AMOUNTCOLLECTION' AND POST_FOR_REGISTRAION_SETT.post_sub_type='BANQUET' AND POST_FOR_REGISTRAION_SETT.post_remarks='Registration_Payment')-- FOR REGISTRAION PAYMENT
	  
         --   LEFT  join FO_POSTING POST_FO_SETT ON (POST_FO_SETT.post_bill_no = POST_FOR_REGISTRAION_SETT.post_bill_no AND POST_FO_SETT.POST_TYPE='AMOUNTCOLLECTION' AND POST_FO_SETT.post_sub_type='CHECKOUTPAYMENT')-- FOR REGISTRATION PAYMENT SETTLEMENT

		    left  JOIN dbo.[Transaction] ACC_TRANS ON  ACC_TRANS.RefId = BNQT_BILL.bqt_bill_id AND (ACC_TRANS.RefSource = 'BNQT_SETT' OR ACC_TRANS.RefSource = 'BNQTBILLTOCMP_SETT')
         LEFT JOIN dbo.Prl_Employee EMP ON EMP.Id = BNQT_BILL.bqt_usr_id
            LEFT JOIN dbo.aspnet_Users USR ON EMP.user_id = USR.UserId
		    WHERE    
		     (
            ( @DATE_FILTER_TYPE = 'TRNS_DATE' AND  (BNQT_BILL.bqt_bill_Date BETWEEN @FROM_DATE AND @TO_DATE ))
            OR ( @DATE_FILTER_TYPE = 'ACC_DATE' AND CONVERT(DATE,ACC_TRANS.TransactionDate) BETWEEN @FROM_DATE AND @TO_DATE)
            )
    END

	UPDATE @RESULT_TEMP
		SET 
		TOTALAMT = (SALES+SC+VAT)*EXCH_RATE
		, VATABLE =    (SALES+SC)*EXCH_RATE 
		,SALES = (SALES)*EXCH_RATE
		,SC = SC*EXCH_RATE
		,VAT=VAT*EXCH_RATE
        WHERE is_Active ='yes'
		
	--NIRE:	-----------------------------------------------------
	--IF(@TYPE = 'Tariff and Plan')
	--BEGIN
		DECLARE @INVOICENO VARCHAR (50) = ''	
		DECLARE @DUP_DATE VARCHAR (20) = ''	
		DECLARE @DUP_TRANSID BIGINT
		DECLARE CUR_DUPLICATE  CURSOR FAST_FORWARD FOR
			SELECT INVOICENO FROM  @RESULT_TEMP GROUP BY INVOICENO HAVING COUNT(INVOICENO) > 1
		OPEN CUR_DUPLICATE
		FETCH NEXT FROM CUR_DUPLICATE INTO @INVOICENO
					 
		WHILE (@@FETCH_STATUS=0)
		BEGIN
			SET @DUP_DATE= (SELECT TOP 1 ACC_dATE FROM @RESULT_TEMP WHERE INVOICENO =  @INVOICENO and  ACC_dATE is not null)
			UPDATE @RESULT_TEMP SET ACC_dATE = @DUP_DATE WHERE INVOICENO =  @INVOICENO
			
			SET @DUP_DATE= (SELECT TOP 1 [DATE] FROM @RESULT_TEMP WHERE INVOICENO =  @INVOICENO and  [DATE] is not null)
			UPDATE @RESULT_TEMP SET [DATE] = @DUP_DATE WHERE INVOICENO =  @INVOICENO
			
			SET @DUP_TRANSID= (SELECT TOP 1 TransactionRefId FROM @RESULT_TEMP WHERE INVOICENO =  @INVOICENO and TransactionRefId > 0)
			UPDATE @RESULT_TEMP SET TransactionRefId = @DUP_TRANSID WHERE INVOICENO =  @INVOICENO
				 
		FETCH NEXT FROM CUR_DUPLICATE INTO @INVOICENO
		
		END
		DEALLOCATE CUR_DUPLICATE
	--END
	
	-----------------------------------------------------------
		
	insert into @RESULT_TEMP_noVoid 
	select DISTINCT * from @RESULT_TEMP r
	where is_active = 'YES'
	--( ( SUBSTRING(r.DATE, len(r.DATE)-4,4) <> 'void')
	--and   
	--( SUBSTRING(r.INVOICENO, len(r.INVOICENO)-4,4) <> 'void')
	--)

		
	INSERT INTO @RESULT_TEMP_ORDER(DATE,acc_date,INVOICENO,TOTALAMT,SALES,SC,VATABLE,VAT,BUYERNAME,TPIN ,DISCOUNT,bold,filter,Entered_by,is_active,RefId,TransactionRefId)
		SELECT 
        DISTINCT
        DATE
		,acc_date
        ,INVOICENO
		,CONVERT(NUMERIC(18,2),ROUND( TOTALAMT,2))
		,CONVERT(NUMERIC(18,2), ROUND( SALES,2))
		,CONVERT(NUMERIC(18,2),ROUND( SC,2))
		,CONVERT(NUMERIC(18,2),ROUND( VATABLE,2))
		,CONVERT(NUMERIC(18,2),ROUND( VAT,2) )
		,BUYERNAME
		,TPIN
		,CONVERT(NUMERIC(18,2),ROUND( DISCOUNT,2) )
		,bold
		,filter
        ,Entered_by
        ,is_Active
        ,RefId
        ,isnull(TransactionRefId,'')
		FROM @RESULT_TEMP	
	
	INSERT INTO @RESULT (DATE,acc_date,INVOICENO,TOTALAMT,SALES,SC,VATABLE,VAT,BUYERNAME,TPIN ,DISCOUNT,bold,Entered_by,is_Active,RefId,Fiscal_Year,TransactionRefId)
		SELECT 
        DATE
		,acc_date
        ,INVOICENO
		,CONVERT(NUMERIC(18,2),ROUND( TOTALAMT,2))
		,CONVERT(NUMERIC(18,2), ROUND( SALES,2))
		,CONVERT(NUMERIC(18,2),ROUND( SC,2))
		,CONVERT(NUMERIC(18,2),ROUND( VATABLE,2))
		,CONVERT(NUMERIC(18,2),ROUND( VAT,2) )
		,BUYERNAME
		,TPIN
		,CONVERT(NUMERIC(18,2),ROUND( DISCOUNT,2) )
		,bold
        ,Entered_by
        ,is_Active
        ,RefId
        ,F.Name
        ,TransactionRefId
		FROM @RESULT_TEMP_ORDER R
        Left JOIN dbo.FiscalYear F ON F.StartDate<= R.DATE AND F.EndDate>= R.DATE
		order by filter
	if(@WithTotal=1)
	Begin
		insert into @RESULT(TOTALAMT,VATABLE,SALES,SC,VAT,bold,BUYERNAME,Date,discount)
		values
		(
		(select SUM(TOTALAMT) from @RESULT_TEMP_noVoid)
		,(select SUM(VATABLE) from @RESULT_TEMP_noVoid)
		,(select SUM(SALES) from @RESULT_TEMP_noVoid)
		,(select SUM(SC) from @RESULT_TEMP_noVoid)
		,(select SUM(VAT) from @RESULT_TEMP_noVoid)
		,1
		,''--TOTAL'
		,'TOTAL'--case when @TYPE='POS' THEN 'TOTAL' ELSE '' END
	,(select SUM(discount) from @RESULT_TEMP_noVoid)
		)
		
		SELECT 
		--DISTINCT
		ISNULL(R.Fiscal_Year ,'')FiscalYear
		,ISNULL(DATE,'')DATE,
		ISNULL(acc_Date,'')ACC_DATE
		,ISNULL(INVOICENO,'')INVOICENO
		,ISNULL(BUYERNAME,'')BUYERNAME
		,ISNULL(TPIN,'')TPIN
		,ISNULL(TOTALAMT,'')TOTALAMT
		,ISNULL(SALES,'')SALES
		,(case when ISNULL(TOTALAMT,'')='' then '' else  ISNULL(DISCOUNT,'') end )DISCOUNT
		,ISNULL(SC,'')SC
		,ISNULL(VATABLE,'')VATABLE
		,ISNULL(VAT,'')VAT

		,ISNULL(Entered_by,'') EnteredBy
		,ISNULL(is_Active,'')IsActive
		--,CASE WHEN ISNULL(r.refID,0)!=0  THEN CASE WHEN ISNULL(prt.print_dtls_id,0)=0 THEN 'NO' ELSE 'YES' END  ELSE '' end AS IS_Printed 
		    ,CASE WHEN ISNULL(prt.print_dtls_id,0)<>0 THEN 'YES'  
                 WHEN ISNULL(posPrt.print_dtls_id ,0)<>0 THEN 'YES' 
                 WHEN ISNULL(bnqtPrt.print_dtls_id,0)<>0 THEN 'YES' 
        ELSE 'NO' END  IS_Printed 
        ,ISNULL(EMP.EmployeeName,'') printed_name
      ,CASE WHEN ISNULL(prt.print_dtls_id,0)<>0  THEN CONVERT(NVARCHAR(50),CONVERT(DATE,   prt.print_date ) ) +' '+CONVERT(VARCHAR(5), prt.print_date,108) 
         WHEN ISNULL( posPrt.print_dtls_id,0)<>0  THEN CONVERT(NVARCHAR(50),CONVERT(DATE,   posPrt.print_date ) ) +' '+CONVERT(VARCHAR(5), posPrt.print_date,108) 
         WHEN ISNULL( bnqtPrt.print_dtls_id,0)<>0  THEN CONVERT(NVARCHAR(50),CONVERT(DATE,   bnqtPrt.print_date ) ) +' '+CONVERT(VARCHAR(5), bnqtPrt.print_date,108) 
            ELSE ''
          END Printed_time
		,ISNULL(bold,0) bold
		 FROM @RESULT r
		LEFT OUTER JOIN dbo.fo_g_bill_print_dtls prt ON  prt.print_dtls_id = 
		( SELECT TOP 1 print_dtls_id FROM dbo.fo_g_bill_print_dtls 
			WHERE  r.refID =bill_dtls_id 
			AND src = CASE WHEN(@TYPE ='LAUNDRY') THEN 'LaundryBill'
							WHEN(@TYPE ='Others') THEN 'OtherServiceBill'
							WHEN(@TYPE ='Tariff and Plan') THEN 'CheckOutBill'
					   ELSE '' END
		 ORDER BY print_date )
		 LEFT OUTER JOIN dbo.pos_bill_print_dtls posPrt ON  prt.print_dtls_id = 
		( SELECT TOP 1 print_dtls_id FROM dbo.fo_g_bill_print_dtls 
		   WHERE  r.refID =bill_dtls_id  AND @TYPE ='POS'
		   ORDER BY print_date )
        LEFT OUTER JOIN dbo.bnqt_bill_print_dtls bnqtPrt ON bnqtPrt.print_dtls_id = 
        (SELECT TOP 1 print_dtls_id  FROM dbo.bnqt_bill_print_dtls WHERE r.refId =  bill_id ORDER BY print_date desc)
		LEFT OUTER JOIN dbo.Prl_Employee EMP ON( EMP.Id = prt.print_by OR EMP.Id = posPrt.print_by OR EMP.Id = bnqtPrt.print_by)
		LEFT OUTER JOIN dbo.aspnet_Users USR ON EMP.user_id = USR.UserId	
	End
	Else
	Begin
		Select *from @RESULT
    END
END

