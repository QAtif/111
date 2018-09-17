<%@ Page Title="" Language="C#" MasterPageFile="~/AreaMaster.master" AutoEventWireup="true" CodeFile="tipsguides.aspx.cs" Inherits="area_tipsguides" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContainer" Runat="Server">
    <script type="text/javascript">
        xPageELEM = 4;
    </script>
    <style type="text/css">
        .taglinks
        {
            display: block;
            background: #CDE2F6;
            border: 1px solid #BFDAF7;
            color: #036;
            font-size: 11px;
            -webkit-border-radius: 3px;
            -moz-border-radius: 3px;
            border-radius: 3px;
            padding: 03px 6px 03px 5px;
            float: left;
            margin-right: 5px;
            margin-top: 5px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentContainer" Runat="Server">
    <div class="noclosebtn">
 <div id="main">
        <header>
   
    <div class="row-fluid myboxview" id="gtg-generalsgst" style="display:none">
   	  	<div class="xbox2 notification ">
        <div class="span12">
          <h3>General Tips &amp; Guides</h3>
          <p><asp:Label ID="lblNameGen" runat="server" Visible="false"></asp:Label>, we suggest you go through our tips &amp; guidelines before you start with your application process.<br>
            Here are some tips that will help you slide through our process smoothly.  </p>
            <p class="tips"><span>Bonus Tips:</span>    Choose your skill set carefully so that you can be contacted for any openning, yes other than the ones you applied for.</p>
        </div>
        
        <a href="javascript:void(0);" class="xclose" title="Close">Close</a> </div>
    </div>
	
    <div class="row-fluid myboxview" id="gtg-testsgst" style="display:none">
   	  	<div class="xbox2 notification ">
        <div class="span12">
          <h3>Test Tips &amp; Guidelines</h3>
          <p><asp:Label ID="lblNameTest" runat="server" Visible="false"></asp:Label>, we suggest you go through our tips &amp; guidelines about the test. Here are some tips that will help you prepare for the big day, you can also practice by downloading the sample test to get an idea.</p>
  <p class="tips"><span>Bonus Tips:</span>   Keep your nerves under control. Keep track of the time, spending too much time on one section is never a good idea. </p>
        </div>
        
        <a href="javascript:void(0);" class="xclose" title="Close">Close</a> </div>
    </div>
    
    <div class="row-fluid myboxview" id="gtg-interviewsgst" style="display:none">
   	  	<div class="xbox2 notification ">
        <div class="span12">
          <h3>Interview Tips &amp; Guidelines</h3>
          <p>Here are some tips that will help you prepare for the interview day, rehearse your answers, follow the dress code and believe in yourself.  </p>
  <p class="tips"><span>Bonus Tips:</span>    Keep your nerves under control. Keep track of the time, spending too much time on one section is never a good idea. </p>
        </div>
        
        <a href="javascript:void(0);" class="xclose" title="Close">Close</a> </div>
    </div>
    
    <div class="row-fluid myboxview" id="gtg-offersgst" style="display:none">
   	  	<div class="xbox2 notification ">
        <div class="span12">
          <h3>Offer Tips &amp; Guidelines</h3>
          <p>Congratulations! You cleared our recruitment phases and are now shortlisted for the position. We recommend you go through our job offer carefully and make a wise decision. </p>
  <p class="tips"><span>Bonus Tips:</span>    We offer salaries 2 times above the existing market value, plus an extraordinary lifestyle that is one of its kind.  </p>
        </div>
        
        <a href="javascript:void(0);" class="xclose" title="Close">Close</a> </div>
    </div>
    
    <div class="row-fluid myboxview" id="gtg-docsubsgst" style="display:none">
   	  	<div class="xbox2 notification ">
        <div class="span12">
          <h3>Document Submission Tips &amp; Guidelines</h3>
          <p>Congratulations and thank you for accepting our job offer. Now is the time to submit your original documents, list of which is already provided to you by our HR representative.</p>
  <p class="tips"><span>Bonus Tips:</span>  Never submit a fake document, if you don't have a certain document you can honestly discuss and see what we can do about it. </p>
        </div>
        
        <a href="javascript:void(0);" class="xclose" title="Close">Close</a> </div>
    </div>
    
    <div class="row-fluid myboxview" id="gtg-joiningsgst" style="display:none">
   	  	<div class="xbox2 notification ">
        <div class="span12">
          <h3>Joining Tips &amp; Guidelines</h3>
          <p>We welcome you onboard. You are amongst the few individuals who are the part of the company. Now you can play your part and make a difference in your life, your homeland, and the world.</p>
  <p class="tips"><span>Bonus Tips:</span> Everyone is your friend, you will find Bol a friendly place. All you need is the right attitude.</p>
        </div>
        
        <a href="javascript:void(0);" class="xclose" title="Close">Close</a> </div>
    </div>
    
  </header>
        <div class="row-fluid" id="gtg-general" style="display: none">
            <div class="span12">
                <div class="xbox-with-heading reset alltabs">
                    <div class="tab1 active">
                        <h3>
                            The Right Way to Fill The Form?</h3>
                        <span class="colone">
                            <h4>
                                Filling the application form is
                                <br>
                                the first step.</h4>
                            <p>
                                Make sure you check mark all the do?s and don?ts before you fill the most important
                                piece of information.<br>
                                <br>
                                Leaving out any important details, missing fields and not providing the asked documents
                                may lead to disqualification even before the process begins.
                            <br>
<br>
                                Wish You Good Luck!</p></span>
                        <div class="section2">
                            <img src="/Area/assets/img/new/fillformimg.png" alt="">
                        </div>
                        <div class="section3">
                            <h4>
                                Things You Should Know:</h4>
                            <ul>
                                <li>Read and understand before you enter any information.</li>
                                <li>Make sure the information you enter is accurate.</li>
                                <li>Documents should support the information you entered.</li>
                                <li>Do not miss out any fields, specially the one with mandatory fields with the * sign.</li>
                                <li>In case you don?t complete your form, all your information will be saved.</li>
                                <li>You can complete your information on your next visit.</li>
                            </ul>
                        </div>
                    </div>
                    <div class="threetabarea tab2">
                        <h3>
                            6 Things to Note while Creating a Resume</h3>
                        <span class="colone">
                            <h4>
                                Get exclusive tips on<br>
                                creating a perfect
                                <br>
                                resume.</h4>
                            <p>
                                Make sure you check mark all the do?s and don?ts before you upload your resume to
                                avoid all resume-faux-pas.
                                <br>
                                <br>
                                Get bonus tips on what to do and what not to do during your interview to make a
                                winning impression.</p>
                        </span>
                        <div class="section2">
                            <table>
                                <tr>
                                    <td class="width250">
                                        <span>1</span> <strong>Length</strong>
                                        <p>
                                            It?s wiser to create a concise resume. Ideally it should be two page long, but one
                                            page is better.</p>
                                    </td>
                                    <td>
                                        <span>2</span> <strong>Page Margins</strong>
                                        <p>
                                            The standard page margins should be 1" margin on the top, bottom, left and right
                                            sides of the page.</p>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <span>3</span> <strong>Font</strong>
                                        <p>
                                            Don?t use ornate fonts. Resumes that are difficult to read are not appreciated.
                                            <div class="addspc">
                                            </div>
                                            <i class="darkblue">Our tip:</i> use Times New Roman, Arial, Calibri, or a similar
                                            font.</p>
                                    </td>
                                    <td>
                                        <span>4</span> <strong>Layout</strong>
                                        <p>
                                            You can choose any layout, however remain consistent throughout, e.g. if the company
                                            name is in italics, every company name should be in italics.</p>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <span>5</span> <strong>Information to Avoid</strong>
                                        <p>
                                            No need to mention your personal details, unless asked or<br>
                                            required.</p>
                                    </td>
                                    <td>
                                        <span>6</span> <strong>Accuracy</strong>
                                        <p>
                                            Take one last look at your resume; make sure there are no spelling, grammar, tenses
                                            errors.</p>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="section3">
                            <h4>
                                How to make yourself
                                <br>
                                Irreplaceable At Work</h4>
                            <ol>
                                <li>Don't be a know-it-all.</li>
                                <li>Continue to learn.</li>
                                <li>Be knowledgeable, not smart.</li>
                                <li>Get to know your office peeps.</li>
                                <li>Learn the lingo.</li>
                            </ol>
                        </div>
                    </div>
                    <div class="threetabarea tab3">
                        <h3>
                            7 New Rules For Creating The Perfect Cover Letter</h3>
                        <span class="colone">
                            <h4>
                                Get exclusive tips on<br>
                                creating a perfect cover letter.</h4>
                            <p>
                                It is the first document that will make or break your impression on your potential
                                employer. We provide you the exclusive tips and guidelines to standout amongst the
                                thousands of applications we receive every day.
                            </p>
                        </span>
                        <div class="section2">
                            <table>
                                <tr>
                                    <td class="width250">
                                        <span>1</span> <strong>Keep It Short </strong>
                                        <p>
                                            Keep your letter short enough for someone to read in 10 seconds.</p>
                                    </td>
                                    <td>
                                        <span>2</span> <strong>Make It Interesting </strong>
                                        <p>
                                            Hook your reader's interest in the first sentence.</p>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <span>3</span> <strong>Prove Yourself </strong>
                                        <p>
                                            Pick two or three skills from the job description &amp; show you have them.</p>
                                    </td>
                                    <td>
                                        <span>4</span> <strong>Use Math </strong>
                                        <p>
                                            Use numbers and statistics to back up your claims.</p>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <span>5</span> <strong>Avoid Redundancy </strong>
                                        <p>
                                            Don't just rehash your r?sum? in paragraph form.</p>
                                    </td>
                                    <td>
                                        <span>6</span> <strong>To whom it may concern </strong>
                                        <p>
                                            Address your cover letter directly to the hiring manager or recruiter. Never write
                                            to whom it may concern.</p>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <span>7</span> <strong>Seek Help </strong>
                                        <p>
                                            Proofread carefully, and consider getting a second pair of eyes.</p>
                                    </td>
                                    <td>&nbsp;
                                        
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="section3">
                            <h4>
                                Worst Cover Letter Mistakes</h4>
                            <ul class="withhds">
                                <li><span>Mistake #1:</span> Overusing ?I?</li>
                                <li><span>Mistake #2: </span>Using A Weak Opening</li>
                                <li><span>Mistake #3:</span> Omitting Your Top Selling Points</li>
                                <li><span>Mistake #4:</span> Making It Too Long</li>
                                <li><span>Mistake #5:</span> Repeating Your Resume Word for Word</li>
                            </ul>
                        </div>
                    </div>
                    <div class="threetabarea tab4">
                        <h3>
                            Find a Nice Way to Thank!</h3>
                        <span class="colone padtop6 padbot7"><strong class="fa13 darkcolor">Why write a thank
                            you letter?</strong>
                            <h4>
                                You should be able to follow proper pre- employment etiquettes.</h4>
                            <p>
                                For that even after your interview, you should promptly (within 2 business days),
                                write a thank you letter expressing your appreciation and gratitude for your potential
                                employers time and attention. Thank you letter could be in form of a note, an email
                                or a hand written letter depending on your situation.</p>
                        </span>
                        <div class="section2 fourcolored">
                            <table>
                                <tr>
                                    <td class="bluebox">
                                        <span>SAMPLE 1</span><p>
                                            Thanks for the opportunity to discuss the _____role with (your company). I believe
                                            my (A) and (B) skills, combined with significant (C) and (D) experience, would be
                                            an asset to your team. I look forward to future discussions to learn how I can contribute
                                            to your organization?s goals. Sincerely,</p>
                                    </td>
                                    <td class="orangebox">
                                        <span>SAMPLE 2</span><p>
                                            I very much enjoyed our conversation yesterday about the _____________ opportunity
                                            in your team. After our time together, I'm positive that my experience can make
                                            a measurable impact on your department?s deliverables. I hope to hear from you in
                                            the near future. Best regards,</p>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="purplebox">
                                        <span>SAMPLE 3</span><p>
                                            I truly appreciate the time you shared yesterday to talk about the _____ role in
                                            your department. Your insights about the position were very helpful, and I would
                                            enjoy the opportunity to further continue our dialogue and learn more about a career
                                            with (your company). Thanks and regards,</p>
                                    </td>
                                    <td class="greenbox">
                                        <span>SAMPLE 4</span><p>
                                            It was a pleasure meeting you yesterday to learn about the ___________ position
                                            with (your company). I am very interested in learning more and continuing our conversation.
                                            I feel my background is a strong fit for your team. Thanks for the opportunity to
                                            meet, and I look forward to hearing from you. Very truly yours,</p>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="section3">
                            <h4>
                                What should you include in your thank you note</h4>
                            <ul>
                                <li>The hiring manager's name</li>
                                <li>The title of the open position</li>
                                <li>Something about the important items discussed</li>
                                <li>Your interest in the position</li>
                                <li>Appreciating the interviewer(s) for their time.</li>
                            </ul>
                        </div>
                    </div>
                </div>
                <ul class="botnav">
                    <li class="active"><a href="javascript:;" title="" data-rel="tab1">Fill the Form</a></li>
                    <li><a href="javascript:;" title="" data-rel="tab2">Resume Writing</a></li>
                    <li><a href="javascript:;" title="" data-rel="tab3">Cover Letter</a></li>
                    <li><a href="javascript:;" title="" data-rel="tab4">Thank You Letter</a></li>
                </ul>
                <div class="seph">
                </div>
            </div>
        </div>
        <div class="row-fluid" id="gtg-test" style="display: none">
            <div class="span12">
                <div class="xbox-with-heading reset alltabs botpad">
                    <div class="tab5 active">
                        <h3>
                            4 Important Tips about solving IQ Quizzes</h3>
                        <span class="colone width210">
                            <h4>
                                Sample Test</h4>
                            <p>
                                At Bol we want the best for you and strive to help you become the part of an extraordinary
                                enterprise that lives to make a difference in the world.
                                <br>
                                <br>
                                Download our sample test to prepare and practice for our simple yet intellectually
                                challenging test.
                            </p>
                            
                            <button type="button" onclick="window.open('http://careers.Bol.com/RecruitmentDocuments/TestDocuments/SampleTests/ContentSampleTest.pdf')" class="xBook-button-center fill-appForm topmarfix" title="">
                                Download Sample Test</button>
                              
                                </span>
                        <div class="sectionmidfull">
                            <table>
                                <tr>
                                    <td bgcolor="#f6f6f6" class="bdb">
                                        <p class="darkcolor">
                                            For scoring high in an IQ test you don?t necessarily need to have an extra high
                                            IQ, all you need to do is exercise your brain.</p>
                                        <p>
                                            IQ can be improved and a person who initially could not score well in an IQ test
                                            can do better next time after following certain brain exercises.</p>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table>
                                            <tr>
                                                <td class="valign-top">
                                                    <td class="valign-top"><span class="yellowbtn">Writing Exercise</span></td>
                                                </td>
                                                <td>
                                                    <p>
                                                        It is good for you. Writing is said to be the best machine of the "mental gym".
                                                        It provides the perfect workouts for creativity, logic and focus.</p>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="valign-top">
													<td class="valign-top"><span class="yellowbtn">Reading Exercise</span></td>
                                                </td>
                                                <td>
                                                    <p>
                                                        Finish a book every week or at least a month. Reading novels and books leads you
                                                        to a world of imagination and provides a much-needed break to your mind and gray
                                                        cells.
                                                    </p>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="valign-top">
													<td class="valign-top"><span class="yellowbtn">Watching Fiction</span></td>
                                                </td>
                                                <td>
                                                    <p>
                                                        You do it any ways, just watch television, drama, theatre and plays, it makes you
                                                        imagine yourself in that position and leads to a diversion of thoughts.
                                                    </p>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="valign-top">
                                                    <td class="valign-middle"><span class="yellowbtn">Solving Puzzles</span></td>
                                                </td>
                                                <td>
                                                    <p>
                                                        Solve crosswords and puzzles as often as you can. It?s fun and it keeps your brain
                                                        sharp and boosts your learning capabilities.</p>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                    <div class="threetabarea tab6">
                        <h3>
                            4 Tips that will Help You Score Well in Your Comprehension Test</h3>
                        <span class="colone width210">
                            <h4>
                                Sample Test</h4>
                            <p>
                                At Bol we want the best for you and strive to help you become the part of an extraordinary
                                enterprise that lives to make a difference in the world.
                                <br>
                                <br>
                                Download our sample test to prepare and practice for our simple yet intellectually
                                challenging test.
                            </p>
                          
                            <button type="button" onclick="window.open('http://careers.Bol.com/RecruitmentDocuments/TestDocuments/SampleTests/ContentSampleTest.pdf')" class="xBook-button-center fill-appForm topmarfix" title="">
                                Download Sample Test</button>
                               
                                </span>
                        <div class="sectionmidfull">
                            <table class="numbercol4">
                  <tr>
                    <td class="width310"><span><i>1</i> Do as Asked!</span><p>Sometimes thinking outside the box isn?t a good idea. Read the passage carefully at least twice and then answer the questions, do not use
outside knowledge in selecting or formulating your answer.</p></td>
                    <td><span><i>2</i> Obedience is Good!</span><p>Pay extra attention when reading the instructions. Don?t miss important points. For example, if asked for antonyms or synonyms for a particular word in the passage, then consider the context first.</p></td>
                  </tr>
                  <tr>
                    <td><span><i>3</i> Make Tactical Guesses</span><p>Go through the given choices before answering the questions. If you are unsure of the answer, eliminate answers that you have doubts about. If time permits, try to answer all the questions, &amp; later on eliminate the ones you aren?t sure of.</p></td>
                    <td><span><i>4</i> Be Precise!</span><p>In comprehension, always carefully read the questions first so that you know what you are looking for when you go through the passage again. This helps you focus your attention on important words and phrases. </p></td>
                  </tr>
                </table>
                        </div>
                    </div>
                    <div class="threetabarea tab7">
                        <h3>
                            We help you find the much dreaded x</h3>
                        <span class="colone width210">
                            <h4>
                                Sample Test</h4>
                            <p>
                                At Bol we want the best for you and strive to help you become the part of an extraordinary
                                enterprise that lives to make a difference in the world.
                                <br>
                                <br>
                                Download our sample test to prepare and practice for our simple yet intellectually
                                challenging test.
                            </p>
                             
                            <button type="button" onclick="window.open('http://careers.Bol.com/RecruitmentDocuments/TestDocuments/SampleTests/ContentSampleTest.pdf')" class="xBook-button-center fill-appForm topmarfix" title="">
                                Download Sample Test</button>
                              
                                </span>
                        <div class="sectionmidfull quickmath">
                            <table>
                  <tr>
                    <td bgcolor="#f6f6f6" class="bdb"><p class="darkcolor">Math scares many! Regardless of our numerical skills we need to encounter the demon to achieve the best we aim for. Below are some examples and the explanations for you that some level of understanding can be develop on how to solve such questions when you come across.</p></td>
                  </tr>
                  <tr>
                    <td><table width="100%" border="0" cellspacing="0" cellpadding="0">
                      <tr>
                        <td width="130" align="left" valign="top"><strong class="darkcolor">Question: 1</strong><br></td>
                        <td width="320">Which number should come next in this series?<br>
                          25,24,22,19,15
                            <table width="100%" border="0" cellspacing="0" cellpadding="0" style="margin-top:5px;">
                              <tr>
                                <td width="18" valign="middle"><input type="radio" value="radio" disabled>
                                </td>
                                <td valign="bottom">4</td>
                                <td width="18" valign="middle"><input type="radio" value="radio" disabled></td>
                                <td valign="middle">5</td>
                              </tr>
                              <tr>
                                <td valign="middle"><input type="radio" value="radio" disabled></td>
                                <td valign="middle">10</td>
                                <td valign="middle"><input type="radio" value="radio" disabled></td>
                                <td valign="middle">14</td>
                              </tr>
                            </table>                          <br></td>
                        <td rowspan="2" valign="top">
                        	<div class="bluebox">
                            	<strong>Explanation:</strong>
                            	<p>The pattern decreases
progressively: -1, -2, -3, -4, -5</p>
                          </div>
                        </td>
                      </tr>
                      <tr>
                        <td><strong class="darkcolor">Correct answer:</strong></td>
                        <td><strong class="blackcolor">10</strong></td>
                      </tr>
                      <tr>
                        <td colspan="3">
                        	<span class="seph3"></span>
                        </td>
                      </tr>
                      <tr>
                        <td width="130" align="left" valign="top"><strong class="darkcolor">Question: 2</strong><br></td>
                        <td width="320">Which number should come next in this series?<br>
                          3,5,8,13,21
                            <table width="100%" border="0" cellspacing="0" cellpadding="0" style="margin-top:5px;">
                              <tr>
                                <td width="18" valign="middle"><input type="radio" value="radio" disabled>
                                </td>
                                <td valign="bottom">4</td>
                                <td width="18" valign="middle"><input type="radio" value="radio" disabled></td>
                                <td valign="middle">21</td>
                              </tr>
                              <tr>
                                <td valign="middle"><input type="radio" value="radio" disabled></td>
                                <td valign="middle">31</td>
                                <td valign="middle"><input type="radio" value="radio" disabled></td>
                                <td valign="middle">34</td>
                              </tr>
                            </table>                          <br></td>
                        <td rowspan="2" valign="top">
                        	<div class="bluebox">
                            	<strong>Explanation:</strong>
                            	<p>3+5=8, 5+8=13 and so on.</p>
                          </div>
                        </td>
                      </tr>
                      <tr>
                        <td><strong class="darkcolor">Correct answer:</strong></td>
                        <td><strong class="blackcolor">34</strong></td>
                      </tr>
                    </table></td>
                  </tr>
                </table>
                        </div>
                    </div>
                </div>
                <ul class="botnav threetabs">
                    <li class="active"><a href="javascript:;" title="" data-rel="tab5">IQ Quizzes</a></li>
                    <li><a href="javascript:;" title="" data-rel="tab6">English Comprehension</a></li>
                    <li><a href="javascript:;" title="" data-rel="tab7">Quick Math</a></li>
                </ul>
                <div class="seph">
                </div>
            </div>
        </div>
        <div class="row-fluid" id="gtg-interview" style="display: none">
            <div class="span12">
                <div class="xbox-with-heading reset alltabs botpad9">
                    <div class="threetabarea tab8 active">
                        <h3>
                            4 Things to take care of while dressing up for an Interview</h3>
                        <span class="colone width210">
                            <h4 class="uppercase">
                                Interview DOs</h4>
                            <ul class="greenlisting">
                                <li>Do make sure you know where the interview place is.</li>
                                <li>Do prepare and practice for the interview.</li>
                                <li>Do dress the part for the job, the company, the industry. </li>
                                <li>Do plan to arrive about 10 minutes early. </li>
                                <li>Do greet the receptionist or assistant with courtesy and respect. </li>
                            </ul>
                        </span>
                        <div class="section2 semitbl">
                            <table>
                                <tbody>
                                    <tr>
                                        <td bgcolor="#f6f6f6" class="bdb text-center">
                                            <p class="darkcolor mar-bot-zero">
                                                Appearances shouldn't matter, but the plain fact is that you are often judged before
                                                you've even uttered a word.</p>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <ul>
                                                <li>
                                                    <img src="/Area/assets/img/new/dress.jpg" alt="">
                                                    <h4>
                                                        Dress</h4>
                                                    Your clothes (shirt, trousers) should be clean, fitted, and pressed. </li>
                                                <li>
                                                    <img src="/Area/assets/img/new/shoes.jpg" alt="">
                                                    <h4>
                                                        Shoes</h4>
                                                    Your shoes should shine and they must be perfectly clean.</li>
                                                <li>
                                                    <img src="/Area/assets/img/new/hair.jpg" alt="">
                                                    <h4>
                                                        Hair</h4>
                                                    Don?t go to an interview with weird gel styles, spooky colors or tattoos. </li>
                                                <li>
                                                    <img src="/Area/assets/img/new/accessories.jpg" alt="">
                                                    <h4>
                                                        Accessories</h4>
                                                    It is recommended not to wear accessories that grab attention. </li>
                                            </ul>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                        <div class="section3 reset">
                            <h4>
                                Interview DON'Ts</h4>
                            <ul class="crosslisting">
                                <li>Don't chew gum during the interview.</li>
                                <li>Don't rely on your application or resume to do the selling for you. </li>
                                <li>Don't tell jokes during the interview.</li>
                                <li>Don't be soft-spoken. A forceful voice projects confidence.</li>
                                <li>
                                Don't say anything negative about former colleagues, supervisors, or employers.
                            </ul>
                        </div>
                    </div>
                    <div class="threetabarea tab9">
                        <h3>
                            Things you should take care of during an Interview</h3>
                        <span class="colone width210">
                            <h4 class="uppercase">
                                Body Language DOs</h4>
                            <ul class="normallisting">
                                <li>Sit up straight, and lean slightly forward in your chair.</li>
                                <li>Show your enthusiasm by keeping an interested expression.</li>
                                <li>Offer a firm handshake, make eye contact.</li>
                                <li>Maintain good eye contact during the interview.</li>
                                <li>Establish a comfortable amount of personal space between you and the interviewer.
                                </li>
                            </ul>
                        </span>
                        <div class="section2 bgcenterimg">
                            <p class="bluetext">
                                Experts in the field of body language advice that candidates should change positions
                                throughout the interview; such as move around in the chair, change hand position
                                etc. This type of actions eases you out of stage fright and stops you from getting
                                stuck.
                            </p>
                            <ul>
                                <li>Rub the back of your head or neck.</li>
                                <li>Sit with your armed folded across your chest. You'll appear unfriendly and disengaged.
                                </li>
                                <li>Cross your legs and idly shake one over the other.</li>
                                <li>Lean your body towards the door. You'll appear ready to make a mad dash for the
                                    door.</li>
                                <li>Slouch back in your seat. This will make you appear disinterested and unprepared.
                                </li>
                            </ul>
                        </div>
                        <div class="section3 reset">
                            <h4 class="bulbicon">
                                Bonus Tip</h4>
                            <p class="fa13 padleft14">
                                Some hiring managers claim they can spot a possible candidate for a job within 30
                                seconds or less, and while a lot of that has to do with the way you look, it's also
                                in your body language. Don't walk in pulling up or readjusting your tie; pull yourself
                                together before you stand up to greet the hiring manager or enter their office.</p>
                        </div>
                    </div>
                    <div class="threetabarea tab10">
                        <h3>
                            Difficult Questions... No Problem!</h3>
                        <span class="colone width210">
                            <h4 class="uppercase">
                                Crucial Questions about your abilities.</h4>
                            <ul class="normallisting">
                                <li>Describe a decision you made that was a failure. What happened and why?</li>
                                <li>Tell me about a time that you worked conveying technical information to a nontechnical
                                    audience.</li>
                                <li>Tell me about a time that you worked with data, interpreting data, and presenting
                                    data.</li>
                                <li>Why do you think you will be successful at this job?</li>
                            </ul>
                        </span>
                        <div class="section2 semitbl qalisting">
                            <table>
                                <tbody>
                                    <tr>
                                        <td class="bdb bgredicon">
                                            <p>
                                                Your interviewer may ask tricky questions. The trick is to keep your nerves under
                                                control and you can come up with the fabulous answers for frightening questions
                                                and of course we tip you for that:</p>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <ul class="qatbl">
                                                <li><span class="q">Q</span> <strong>What could you bring to the job?</strong> </li>
                                                <li><span class="a">A</span> If you have carefully read the job application and researched
                                                    the company you should know what they want. </li>
                                                <li><span class="q">Q</span> <strong>What is your greatest achievement?</strong>
                                                
                                                    
                                                    
                                                    
                                                    </li>
                                                    <li><span class="a">A</span> Think of something you have achieved and how it developed
                                                        you. the event may have given you relevant job skills. </li>
                                                    <li><span class="q">Q</span> <strong>What are your weaknesses?</strong> </li>
                                                    <li><span class="a">A</span> Avoid clich?s such as ?I am a bit of a perfectionist?.
                                                        They all have heard these answers many times before. Instead pick a genuine weakness
                                                        but don?t be too honest. </li>
                                                </ul>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                            <div class="section3 reset">
                                <h4 class="bulbicon">
                                    Bonus Tip</h4>
                                <p class="fa13 padleft14">
                                    Some hiring managers claim they can spot a possible candidate for a job within 30
                                    seconds or less, and while a lot of that has to do with the way you look, it's also
                                    in your body language. Don't walk in pulling up or readjusting your tie; pull yourself
                                    together before you stand up to greet the hiring manager or enter their office.</p>
                            </div>
                        </div>
                    </div>
                    <ul class="botnav threetabs">
                        <li class="active"><a href="javascript:;" title="" data-rel="tab8">Dress Code</a></li>
                        <li><a href="javascript:;" title="" data-rel="tab9">Body Language</a></li>
                        <li><a href="javascript:;" title="" data-rel="tab10">Wisecracks</a></li>
                    </ul>
                    <div class="seph">
                    </div>
                </div>
            </div>
            <div class="row-fluid" id="gtg-offer" style="display: none">
                <div class="span12">
                    <div class="xbox-with-heading reset alltabs botpad9 bdbadd">
                        <div class="threetabarea tab9 active">
                            <h3>
                                If you get a job offer from Bol consider yourself lucky because...</h3>
                            <span class="colone width210">
                                <h4 class="uppercase">
                                    Why Bol?
                                </h4>
                                <ul class="normallisting">
                                    <li>Bol offers amazing lifestyle</li>
                                    <li>Well structured fast paced career path</li>
                                    <li>Extravagant job benefits</li>
                                    <li>Strong recognition system for performers</li>
                                    <li>Highest salary packages</li>
                                    <li>On job training and development</li>
                                </ul>
                            </span>
                            <div class="section2 bgcenterimg fixtbl">
                                <table>
                                    <tbody>
                                        <tr>
                                            <td bgcolor="#f6f6f6" class="bdb">
                                                <p>
                                                    You are about to become the part of world?s leading IT company. At Bol we provide
                                                    a very comfortable and exciting lifestyle. The benefits we offer are in a class
                                                    of their own and of the highest quality in terms of service standards and equipment.
                                                    <br>
                                                    <br>
                                                    Some of the outstanding perks are:</p>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                                <br>
                                <ul>
                                    <li>Bol's Iconic Yacht that has been designed to reflect the organizations best qualities.</li>
                                    <li>Clubs facility which ensures that Bolians can have an entertaining experience
                                        with their family.</li>
                                    <li>Bol's ultramodern hut by the seaside is the perfect place for departmental as
                                        well as personal picnics. </li>
                                </ul>
                                <br>
                                <p class="lastp">
                                    ...and so much more, waiting to be explored.</p>
                            </div>
                            <div class="section3 reset">
                                <h4 class="bulbicon">
                                    Bonus Tip</h4>
                                <p class="fa13 padleft14">
                                    If you have any questions and queries regarding your job offer at Bol you can
                                    freely discuss it with our HR representative. They are here to make you understand
                                    each clause.
                                    <br>
                                    <br>
                                    Looking forward to seeing you onboard!
                                </p>
                            </div>
                        </div>
                    </div>
                    <div class="seph">
                    </div>
                </div>
            </div>
            <div class="row-fluid" id="gtg-docsub" style="display: none">
                <div class="span12">
                    <div class="xbox-with-heading reset alltabs botpad9 bdbadd">
                        <div class="threetabarea tab9 active">
                            <h3>
                                Document Submission is Important.</h3>                          
                            <div class="section2 bgcenterimg fixtbl">
                                <table>
                                    <tbody>
                                        <tr>
                                            <td bgcolor="#f6f6f6" class="bdb">
                                                <p>
                                                    There are certain things that you should take care of while submitting your academic
                                                    documents and other asked papers.</p>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                                <br>
                                <ul>
                                    <li>All academic documents must be original and attested.</li>
                                    <li>Provide your family's details as asked, along with their id cards.</li>
                                    <li>Do not take risk by sumitting fake documents, it may lead to disqualification.</li>
                                    <li>Submit all the required medical reports as asked by our HR representative.</li>
                                </ul>
                            </div>
                            <div class="section3 reset">
                                <h4 class="bulbicon">
                                    Bonus Tip</h4>
                                <p class="fa13 padleft14">
                                    If you have any questions and queries regarding document submission discuss it with
                                    our HR representative. They are here to make you understand each clause.
                                    <br>
                                    <br>
                                    Looking forward to seeing you onboard!
                                </p>
                            </div>
                        </div>
                    </div>
                    <div class="seph">
                    </div>
                </div>
            </div>
            <div class="row-fluid" id="gtg-joining" style="display: none">
                <div class="span12">
                    <div class="xbox-with-heading reset alltabs botpad9 bdbadd">
                        <div class="threetabarea tab9 active">
                            <h3>
                                You are now onboard<img src="/Area/assets/img/smiley-face.jpg" width="20px"  height="20px" /></h3>
                            <span class="colone width210">
                                <h4 class="uppercase">
                                    Enjoy...</h4>
                                <ul class="normallisting">
                                    <li>The amazing lifestyle</li>
                                    <li>The well structured fast paced career path</li>
                                    <li>The extravagant job benefits</li>
                                    <li>The strong recognition system for performers</li>
                                    <li>The Highest salary packages</li>
                                    <li>On job training and development </li>
                                </ul>
                            </span>
                            <div class="section2 bgcenterimg fixtbl">
                                <table>
                                    <tbody>
                                        <tr>
                                            <td bgcolor="#f6f6f6" class="bdb">
                                                <p>
                                                    Now the extraordinary journey begins, you can experience world's best infrastructure
                                                    with the amazing benefits your job offers.
                                                </p>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                                <br>
                                <ul>
                                    <li>You can enjoy flexible timmings.</li>
                                    <li>Order food from your portal.</li>
                                    <li>Book a slot from your portal for saloon or gym.</li>
                                    <li>Take a break from days work and enjoy indoor games.</li>
                                </ul>
                            </div>
                            <div class="section3 reset">
                                <h4 class="bulbicon">
                                    Bonus Tip</h4>
                                <p class="fa13 padleft14">
                                    If you have any questions and queries regarding your orientation discuss it with
                                    our HR representative. They are here to help you.
                                    <br>
                                    <br>
                                    Welcome onboard!
                                </p>
                            </div>
                        </div>
                    </div>
                    <div class="seph">
                    </div>
                </div>
            </div>
            <div class="row-fluid" style="width: 1000px;">
                <div class="span12">
                    <ul class="bottomboxes">
                        <li id="gtg-generalbox">
                            <div class="xbox-with-heading" id="gtgbox">
                                <h3>
                                    General</h3>
                                <span class="addpadtobox">
                                    <img src="/Area/assets/img/new/career.jpg" alt="">
                                    <p>
                                        Go through our general tips and guidelines about filling the form, creating a perfect
                                        resume, cover letter and so on. Gear up as we lead you through the entire procedure
                                        smoothly.
                                    </p>
                                    <a href="../Area/tipsguides.aspx?var=gtg-general" class="xBook-button-center fill-appForm"
                                        title="">Learn More</a></span>
                            </div>
                        </li>
                        <li id="gtg-testbox">
                            <div class="xbox-with-heading">
                                <h3>
                                    Test Tips &amp; Guidelines</h3>
                                <span class="addpadtobox">
                                    <img src="/Area/assets/img/new/testimg.jpg" alt="">
                                    <p>
                                        Once you fill in the form your application will be received by recruitment department
                                        immediately, who will contact the shortlisted candidates for the test, if the position
                                        you applied for requires test assessment.
                                    </p>
                                    <a href="../Area/tipsguides.aspx?var=gtg-test" class="xBook-button-center fill-appForm"
                                        title="">Learn More</a></span>
                            </div>
                        </li>
                        <li id="gtg-interviewbox">
                            <div class="xbox-with-heading">
                                <h3>
                                    Interview Tips &amp; Guidelines</h3>
                                <span class="addpadtobox">
                                    <img src="/Area/assets/img/new/interview.jpg" alt="">
                                    <p>
                                        A successful test will lead to an interview call. The time and place are communicated
                                        to you via various mediums to ensure your presence. Find out bonus tips about your
                                        big day.</p>
                                    <a href="../Area/tipsguides.aspx?var=gtg-interview" class="xBook-button-center fill-appForm"
                                        title="">Learn More</a></span>
                            </div>
                        </li>
                        <li id="gtg-offerbox">
                            <div class="xbox-with-heading">
                                <h3>
                                    Offer Tips &amp; Guidelines</h3>
                                <span class="addpadtobox">
                                    <img src="/Area/assets/img/new/offer.jpg" alt="">
                                    <p>
                                        After an in-person interview, you will be called to discuss the job offer. Amongst
                                        the chosen few, this opportunity will give you a chance to go through each part
                                        of the offer in detail.</p>
                                    <a href="../Area/tipsguides.aspx?var=gtg-offer" class="xBook-button-center fill-appForm"
                                        title="">Learn More</a></span>
                            </div>
                        </li>
                        <li id="gtg-docsubbox">
                            <div class="xbox-with-heading">
                                <h3>
                                    Document Submission Tips &amp; Guidelines</h3>
                                <span class="addpadtobox">
                                    <img src="/Area/assets/img/new/docsub.jpg" alt="">
                                    <p>
                                        You are talented enough to be selected, now is the time you submit your official
                                        documents. Find out important things that you should take care of while submitting
                                        your documents.</p>
                                    <a href="../Area/tipsguides.aspx?var=gtg-docsub" class="xBook-button-center fill-appForm"
                                        title="">Learn More</a></span>
                            </div>
                        </li>
                        <li id="gtg-joiningbox">
                            <div class="xbox-with-heading">
                                <h3>
                                    Joining Tips &amp; Guidelines</h3>
                                <span class="addpadtobox">
                                    <img src="/Area/assets/img/new/joining.jpg" alt="">
                                    <p>
                                        Congratulations! You are amongst 2% lucky selected individuals. Enjoy and make the most of the opportunities.</p>
                                    <a href="../Area/tipsguides.aspx?var=gtg-joining" class="xBook-button-center fill-appForm"
                                        title="">Learn More</a></span>
                            </div>
                        </li>
                        <li>
                            <div class="xbox-with-heading">
                                <h3>
                                    Life at Bol</h3>
                                <span class="addpadtobox">
                                    <img src="/Area/assets/img/new/lifeaxact.jpg" alt="">
                                    <p>
                                        Join Bol and enjoy the lifestyle that is at par with the salary and benefits provided
                                        to the employees. Bolwala's can enjoy the privilege of using 38+ facilities.</p>
                                    <a href="https://www.bolnetwork.com/careers/" target="_blank" class="xBook-button-center fill-appForm"
                                        title="">Learn More</a></span>
                            </div>
                        </li>
                    </ul>
                    <div class="seph2 fixit">
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script>
        $(document).ready(function (e) {

            $('ul.xfamilyUL li:gt(1)').hide();
            $('.xfamilyUL-a').click(function () {
                $('ul.xfamilyUL li:gt(0)').show();
                $(this).hide();
            });

            /* Tabs */
            $('.tabcontroller li a').click(function (e) {
                $(this).addClass('active');
                var relval = $(this).attr('data-rel');
                $('.tabs-content div').hide();
                $('.' + relval).fadeIn("fast");
                $(this).parents().siblings().children().removeClass('active');
            });

            /* Tips and guide tabs */
            $('.botnav li a').click(function (e) {
                $(this).parents().addClass('active');
                var relval = $(this).attr('data-rel');
                $('.alltabs > div').hide();
                $('.' + relval).fadeIn("fast");
                $(this).parents().siblings().removeClass('active');
            });


            function getUrlVars() {
                var vars = [], hash;
                var hashes = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
                for (var i = 0; i < hashes.length; i++) {
                    hash = hashes[i].split('=');
                    vars.push(hash[0]);
                    vars[hash[0]] = hash[1];
                }
                return vars;
            }

            var first = getUrlVars()["var"];
            if (first == first) {
                $('#' + first).show();
                $('#' + first + 'box').hide();
                $('#' + first + 'sgst').show();
            }
        });
    </script>

</asp:Content>

